# - Conestoga Insiders Club -
A website that manages membership in the club and provides features that will attract and retain the interest of club members. Providing a service that enables users to purchase and review games online.

## - Features -
* User accounts
* Game reviewing and purchasing
* Friending system
* Game wishlisting
* Event registration
* Admin dashboard & moderation tools
* Report generating system

## - Development -

### Entity Framework Core

#### Installation

`dotnet tool install -g dotnet-ef`

#### Commands

Apply migrations
`dotnet ef database update`

Drop database
`dotnet ef database drop`

Add migration
`dotnet ef migrations add <NameOfMigration>`

### Formatting

#### Installation

`dotnet tool install -g dotnet-format`

#### Commands

Run linter

`dotnet format`

### SendGrid

In order to enable sending real emails, you'll need to add a SendGrid API key:

`dotnet user-secrets set SendGridKey <key>`


### Tests

For running tests run the project locally through the terminal using the command:
`dotnet run`
Then, run the needed tests through the Test Explorer window.

Before running the tests make sure to enable ssl (trust the localhost) with this command:
`dotnet dev-certs https --trust`
