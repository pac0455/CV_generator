# CV Generator (.NET + QuestPDF)

## Overview

This project is a .NET-based CV generator that transforms structured JSON data into professional PDF documents using QuestPDF. It is designed to separate data, configuration, and rendering logic in a maintainable and scalable way.

The system supports multiple output formats (ATS-optimized and visually enhanced CV layouts) while maintaining a single source of truth defined in a JSON file.

---

## Objective

The main objective of this project is:

- Convert structured CV data (JSON) into a PDF document
- Provide both ATS-compatible and visually formatted CV outputs
- Ensure separation of concerns between:
  - Data (JSON)
  - Domain models (C#)
  - Rendering logic (QuestPDF)
  - Configuration (paths, modes)

---

## Project Structure

/Config        -> Application and PDF configuration
/IO            -> JSON loading and persistence logic
/Layaout       -> PDF document definitions (ATS and Pretty versions)
/Models        -> Domain models representing CV structure
/Template      -> Input JSON templates
/output        -> Generated PDF and normalized JSON output

---

## Input Data

The CV is defined in:

Template/base.json

This file contains structured data including:

- Personal information
- Contact details
- Professional profile
- Work experience
- Education
- Technical skills

---

## Output

All generated artifacts are stored in:

/output

Outputs include:

- Francisco_Hidalgo_CV.pdf -> Generated CV document
- base.json -> Normalized version of the input JSON

---

## Configuration

Configuration is centralized in:

Config/AppConfig.cs

Key settings:

- DEV_MODE: Enables preview mode (QuestPDF Companion)
- CvFile: Path to input JSON file
- OutputDir: Directory where all generated files are stored
- OutputPdf: Full path of generated PDF file
- OutputJson: Path for normalized JSON output

---

## Execution Flow

1. Application starts from Program.cs
2. QuestPDF license is initialized
3. JSON is loaded from Template/base.json
4. Data is deserialized into CVData
5. Output directory is created if not exists
6. CV is rendered using CvDocumentAts or alternative layout
7. PDF is generated into /output

---

## Rendering System

- CvDocumentAts: ATS-compatible layout (linear structure, no visual complexity)
- CVDocumentPretty: visually enhanced layout

Both use the same CVData model.

---

## Technologies Used

- .NET 9
- QuestPDF
- System.Text.Json
- C# file system APIs

---

## Notes

- File-based system, no external services required
- Output directory is created automatically at runtime
- Designed to be extensible for additional CV formats
