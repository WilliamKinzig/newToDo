# Hair Salon Friday Independent Project.
## 7/13/18

## James Hanley:
##### Email: hanley.doth@outlook.com
##### Github: github.com/hanleyjames
##### Blog: hanleyjames.github.io
____
# Project Outline and Details

Project details:
Create an app for a hair salon. 
The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist.
The stylists work independently, so each client only belongs to a single stylist.

User Stories:
1. As a salon employee, I need to be able to see a list of all our stylists.
2. As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
3. As an employee, I need to be add new stylists to our system when they are hired.
4. As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.

Naming Requirements:
Use your first name and last name to name your databases in the following way:
1. Production Database: first_last
2. Test Database: first_last_test
Use the following names for your directories:
1. Main Project Folder: HairSalon
2. Test Project Folder: HairSalon.Tests

In the Readme, include detailed setup instructions with all commands necessary to re-create your databases, columns, and tables.
When finished, export the .SQL files holding the information to the top level of the solution folder.
Use the following pattern:

1. Production Database: james_hanley.sql
2. Test Database: james_hanley_test.sql

Previous Objectives:
1. Do MVC routes follow RESTful convention?
2. Tests have complete coverage for all behaviors.
3. All tests are formatted correctly and pass.
4. Classes are encapsulated and getter methods are used to access properties.
5. Logic is easy to understand.
6. Build files are included in the .gitignore file and are not tracked by git.
7. Code and Git documentation follows best practices(Descriptive var names, proper indentation and spacing, separation between front and back-end logic, detailed commit messages in the correct tense, and a well-formatted README)

------
DB Schema:

* |employee|
* |--------|
* |id|
* |name|
* |client_id|
   
* |   client  |
* |-----------|
* |    id     |
* |    name   |
* |employee_id|
------
# Specs and BDD:

|Behavior|Input|Output|
|--------|-----|------|
|GetList of Stylists|getall view is loaded|Employees:List(Employee)|
|Save Stylist in DB|Add stylist|Stylist is added to DB|
|Add Clients|Add a new client button|Client is added to DB with success message|
|See list of all Stylists|Clickable See all Stylist|Lists all stylists|
|Click on stylists for details|Click on stylists ID|Lists stylists details|
|On stylist detail page, add clients|Click on Previous or new client|Success message with client ID added|
|Update Stylist Information|Update stylist name: Jenn Kelly|Jenn Kelly has been updated|
|Delete Stylist Information|Delete Stylist?<(y/n)|Stylist Deleted|
