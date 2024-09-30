using PdfSharp.Pdf;
using System.Drawing;
using PdfSharp.Drawing;
using static System.Console;

namespace BarChartPdfGenerator;

internal class Program
{
    private static void Main(string[] args)
    {
        var chartImagePath = "BarChart.png";
        CreateSampleChartImage(chartImagePath);

        var pdfPath = "BarChartReport.pdf";
        ConvertImageToPdf(chartImagePath, pdfPath);

        WriteLine($"PDF generated at: {Path.GetFullPath(pdfPath)}");
    }

    // Method to create a bar chart image with specified colors and axis labels
    static void CreateSampleChartImage(string imagePath)
    {
        const int width = 600; // Reduced width for better visibility
        const int height = 300; // Reduced height for better visibility
        using var bmp = new Bitmap(width, height);
        using var g = Graphics.FromImage(bmp);
        g.Clear(Color.White);

        // Draw the axes
        g.DrawLine(Pens.Black, 50, height - 50, 50, 50); // Y-axis
        g.DrawLine(Pens.Black, 50, height - 50, width - 50, height - 50); // X-axis

        // Dummy data for months
        string[] categories =
        {
            "Jan", "Feb", "Mar", "Apr", "May", "Jun",
            "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
        };
        int[] values1 = { 10, 20, 30, 40, 30, 50, 20, 40, 10, 30, 20, 50 }; // Green values
        int[] values2 = { 5, 15, 25, 35, 25, 45, 15, 35, 5, 25, 15, 45 }; // Yellow values
        int[] values3 = { 2, 8, 12, 18, 14, 22, 8, 18, 2, 12, 8, 22 }; // Red values

        var barWidth = 25; // Adjusted bar width
        for (var i = 0; i < categories.Length; i++)
        {
            var x = 60 + i * (barWidth + 15); // Adjusted spacing
            var y1 = height - 50 - values1[i] * 4; // Scale for better visualization
            var y2 = height - 50 - values2[i] * 4; // Scale for better visualization
            var y3 = height - 50 - values3[i] * 4; // Scale for better visualization

            // Draw the first part of the column (green)
            g.FillRectangle(Brushes.Green, x, y1, barWidth, values1[i] * 4);

            // Draw the second part of the column (yellow)
            g.FillRectangle(Brushes.Yellow, x, y2, barWidth, values2[i] * 4);

            // Draw the third part of the column (red)
            g.FillRectangle(Brushes.Red, x, y3, barWidth, values3[i] * 4);

            // Draw category labels on the X-axis
            g.DrawString(categories[i], new Font("Arial", 8), Brushes.Black, x, height - 40);
        }

        // Draw Y-axis labels
        for (var j = 0; j <= 5; j++) // Values from 0 to 50
        {
            var yPos = height - 50 - j * 10 * 4; // Scale for better visualization
            g.DrawString((j * 10).ToString(), new Font("Arial", 8), Brushes.Black, 20, yPos);
        }

        // Draw value labels for each segment
        for (var i = 0; i < categories.Length; i++)
        {
            var x = 60 + i * (barWidth + 15); // Adjusted spacing
            var y1 = height - 50 - values1[i] * 4; // Scale for better visualization
            var y2 = height - 50 - values2[i] * 4; // Scale for better visualization
            var y3 = height - 50 - values3[i] * 4; // Scale for better visualization

            g.DrawString(values1[i].ToString(), new Font("Arial", 8), Brushes.White, x + 5, y1 - 15);
            g.DrawString(values2[i].ToString(), new Font("Arial", 8), Brushes.Black, x + 5, y2 - 15);
            g.DrawString(values3[i].ToString(), new Font("Arial", 8), Brushes.Black, x + 5, y3 - 15);
        }

        // Save the chart as PNG
        bmp.Save(imagePath);
    }

    // Method to convert the chart image to a PDF using PdfSharp
    static void ConvertImageToPdf(string imagePath, string pdfPath)
    {
        using PdfDocument pdf = new PdfDocument();
        var page = pdf.AddPage();
        page.Size = PdfSharp.PageSize.A4; // Set the page size to A4
        var gfx = XGraphics.FromPdfPage(page);

        // Load the image
        var image = XImage.FromFile(imagePath);

        // Calculate position to center the image on the page
        double xPos = (page.Width - image.PixelWidth) / 2;
        double yPos = (page.Height - image.PixelHeight) / 2;

        // Adjust position to ensure the entire image fits on the page
        if (yPos < 0) // If image is larger than page height, set Y position to zero
            yPos = 0;
        else
            yPos = (page.Height - image.PixelHeight) / 2; // Center vertically

        // Draw the image onto the PDF page
        gfx.DrawImage(image, xPos, yPos, image.PixelWidth, image.PixelHeight);

        // Save the PDF
        pdf.Save(pdfPath);
    }
}