# 🎸 Guitar API 🎸
The Guitar API aims to provide a structured and accessible dataset of guitar chords and scales, serving as a foundational resource for musicians, developers, and educators. This Minimum Viable Product (MVP) will focus on delivering core functionalities while maintaining flexibility for future enhancements.

## Goals

- Basic Chord & Scale Retrieval: Provide public GET endpoints for accessing predefined chord and scale data.

API Key Authentication for Data Modification: Implement API keys to restrict POST, PUT, and DELETE operations.

- Rate Limiting: Prevent excessive API usage and ensure fair access.

- Structured Data Format: Deliver JSON responses with consistent structure for easy integration.

## Future Considerations

- Support for alternative tunings and custom chord voicings.

- Audio playback functionality for chords and scales.

- Interactive visualization tools.

- Community contributions for expanding the database.

## Technology Stack

- **Backend**: ASP.NET Core (.NET 9)

- **Database**: MS SQL with Dapper for efficient querying.

- **Security**: API Key authentication & rate limiting.

- **Deployment**: Azure App Service (or alternative hosting solutions based on feasibility).
