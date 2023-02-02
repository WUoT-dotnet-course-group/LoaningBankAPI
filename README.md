# Loaning Bank API

## Description

Loaning Bank API provided for communication with LoansComparerApp.

It creates and stores received inquiries and bank offers created over them.

Loaning Bank API shares below functionalities:

- adding **inquiry** and creating **bank offer** over it
- getting particular **inquiry** by id
- getting particular **offer** by id
- getting **list of created offers**
- getting particular **offer status**.
- **uploading** signed document (agreement)
- **downloading** raw document (agreement)
- **accepting/rejecting** particular offer by a bank employee

## Technologies

- Backend:
  - .NET 6

  - ASP.NET Core 6.0

  - Data storage
    - relational SQL database

    - Entity Framework Core (Code First approach)

  - File storage
    - Azure Blob Storage

  - Authentication & Authorization
    - JWT Auth

  - Mapster (<https://github.com/MapsterMapper/Mapster>)

  - SonarLint

- Version control:
  - Git (simplified Git flow)

  - Github (repository hosting)

- CI/CD:
  - GitHub (GitHub Actions)

- Orchestration/Containerization
  - Docker (in the future)

- Project Management / Scrum / Agile:
  - Azure DevOps
