# CV Generator (.NET + QuestPDF)

## Overview

This project is a .NET-based CV generation system that transforms structured JSON data into PDF documents using QuestPDF.

The architecture is designed around separation of concerns, configuration-driven behavior, and extensible rendering strategies.

The system supports multiple output layouts (ATS and Pretty) derived from a single source of truth: a structured CV JSON model.

---

## Requirements

- QuestPDF preview tool installed (for document preview and debugging)

## Documentation Index

### Core Concepts
- Architecture → docs/architecture.md
- Execution Flow → docs/execution-flow.md

### Configuration
- Configuration → docs/configuration.md
- Themes → docs/themes.md

### Rendering
- Rendering Engine → docs/rendering.md

---

## Quick Navigation

If you're new to the project, start here:

1. Architecture (how the system is structured)
2. Execution Flow (how JSON becomes a PDF)
3. Configuration (how behavior is controlled)

For styling and output customization:
- Themes
- Rendering

---

## Design Principles

- Separation of concerns (data vs rendering vs configuration)
- Single source of truth (JSON CV model)
- Extensible layout system (ATS / Pretty / future templates)
- Deterministic PDF output using QuestPDF

---

## Output Modes

- ATS Mode → optimized for parsing systems
- Pretty Mode → visually enhanced human-readable layout

Both modes are generated from the same structured JSON input.

---

## Suggested Reading Order

1. docs/architecture.md
2. docs/execution-flow.md
3. docs/configuration.md
4. docs/rendering.md
5. docs/themes.md

---

