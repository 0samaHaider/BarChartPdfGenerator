Here’s a README file formatted for GitHub:

# Bar Chart PDF Generator

This project is a simple console application that generates a bar chart image and converts it into a PDF file. It demonstrates the use of `System.Drawing` for drawing the chart and `PdfSharp` for creating the PDF.

## Features

- Creates a bar chart with three sets of dummy data represented in different colors (green, yellow, and red).
- Generates a PDF report containing the bar chart.
- Adjustable parameters for chart size, bar width, and spacing.

## Prerequisites

- .NET 6.0 or later
- Visual Studio or any C# IDE
- NuGet packages:
  - `PdfSharp` for PDF creation
  - `System.Drawing.Common` for drawing graphics

## Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/0samaHaider/BarChartPdfGenerator.git
   cd BarChartPdfGenerator
   ```

2. **Open the Project in Visual Studio**

   Open the `.csproj` file in Visual Studio.

3. **Install Required NuGet Packages**

   You can install the required NuGet packages using the Package Manager Console:

   ```bash
   Install-Package PdfSharp
   Install-Package System.Drawing.Common
   ```

## Usage

1. **Run the Application**

   The application generates a sample bar chart image and converts it into a PDF report. To run the application, open the terminal or command prompt, navigate to the project directory, and execute:

   ```bash
   dotnet run
   ```

2. **Output**

   The generated PDF file, named `BarChartReport.pdf`, will be saved in the project directory. You can open this file using any PDF viewer.

## Code Structure

- `Program.cs`: The main entry point of the application. It contains methods for creating a sample chart image and converting it to a PDF.
- `CreateSampleChartImage`: Generates a bar chart image based on predefined dummy data.
- `ConvertImageToPdf`: Converts the generated chart image into a PDF file.

## Customization

You can customize the following parameters in the `CreateSampleChartImage` method:

- **Chart Size**: Adjust the `width` and `height` variables for the size of the chart.
- **Bar Width**: Change the `barWidth` variable to modify the width of the bars.
- **Data Values**: Modify the `values1`, `values2`, and `values3` arrays to represent different datasets.

## License

This project is open-source and available under the [MIT License](LICENSE).

## Acknowledgments

- [PdfSharp](http://www.pdfsharp.net/) for PDF generation.
- [System.Drawing](https://docs.microsoft.com/en-us/dotnet/api/system.drawing) for drawing graphics.
