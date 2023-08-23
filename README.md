
# FullstackAfiliados

This is a simple project that I developed to an interview.




## Tech Stack

**Front:**
- React
- MaterialUi 
- Axios

**Back:** 
- .NET 7
- SQL Server
- Entity Framework Core
- Docker
- XUnit



## Run the project 
### React Project
For run the react app you will need to access the folder fullstackafiliados.webapp inside src folder.

Inside folder fullstackafiliados.webapp run following commands:

```bash
  npm install
```
or
```bash
  yarn install
```

After to download node packages, run:

```bash
  npm start
```
or
```bash
  yarn start
```

#### Pay Attention

Inside src/services folder there is a file called index.ts

```typescript
import axios from "axios";

export const apiFullstackAfiliados = axios.create({
    baseURL: "https://localhost:7097/api/"
});
```

Check if baseURL is the same that .NET project is running.

### .NET Project

In the root repository you will find a file called FullstackAfiliados.sln. Open to run with Rider or Visual Studio.

Before to run the .NET project, you will need SQL Server installed in your marchine.

If you have Docker installed, You should use an sql server container, it is easily to install.

Well, open Api project and find appsettings.json file and locate ConnectionStrings section, you will replace "Server" for you server, "User Id" and "Password" for you user and password.

Now, you need run a command to create your database.

Open your terminal inside FullstackAfiliados.Data project and write the following command:

You must have EF Core CLI installed.

```bash
  dotnet ef database update -s ../FullstackAfiliados.Api
```

If you are using Visual Studio you just open package manager console and write:

```bash
  update-database
```

Well done, the project is ready to run.## About this project

The purpose of this test is to assess your programming skills.

### Before You Start
 
- Prepare the project to be made available on GitHub by copying the contents of this repository to yours (or use the project fork and point it to GitHub). Ensure that the project's visibility is public (remember to reference this challenge in the readme);
- The project should use the specific language for the position you're applying for, e.g., Python, R, Scala, among others;
- Consider a 5-day deadline starting from the beginning of the challenge. If you've been invited to take the test and can't complete it within this period, inform the person who invited you to receive instructions on what to do.
- Document the entire investigative process for activity development (README.md in your repository); the results of these tasks are as important as your thought process and decisions as you complete them, so try to document and present your hypotheses and decisions as much as possible.

## Project Description

An urgent new demand has arisen, and we need an exclusive area to upload a file containing transactions from the sale of products by our customers.

Our platform operates on a creator-affiliate model, meaning a creator can sell their products and have 1 or more affiliates also selling these products, with a commission being paid per sale.

Your task is to build a web interface that enables the upload of a file containing transactions of sold products, normalize the data, and store it in a relational database.

You should use the file sales.txt to test the application. The format is described in the "Input File Format" section.


## Functional Requirements

Your application should:

1. Have a screen (via a form) for uploading the file
2. Parse the received file, normalize the data, and store it in a relational database according to the file interpretation definitions
3. Display the list of imported product transactions by producer/affiliate, along with a total transaction value
4. Handle backend errors and display user-friendly error messages on the frontend.

## Non-Functional Requirements

1. The application should be easy to configure and run, compatible with Unix environments. You should only use free or open-source libraries.
2. Use Docker for the different services that compose the application to ensure it works easily outside of your personal environment.
3. Use any relational database.
4. Use small commits in Git and provide good descriptions for each one.
5. Write unit tests for both the backend and frontend.
6. Make the code as readable and clean as possible.
7. Write code (names and comments) in English. Documentation can be in Portuguese if preferred.

## Bonus Requirements

Your application doesn't need to have these, but we'll be impressed if it does:

1. Have API documentation for the backend.
2. Use docker-compose to orchestrate the services as a whole.
3. Include integration or end-to-end tests.
4. Have all documentation written in easily understandable English.
5. Handle authentication and/or authorization.

## Input File Format

| Campo    | Início | Fim | Tamanho | Descrição                      |
| -------- | ------ | --- | ------- | ------------------------------ |
| Type     | 1      | 1   | 1       | Transaction type               |
| Date     | 2      | 26  | 25      | Date - ISO Date + GMT          |
| Product  | 27     | 56  | 30      | Product description            |
| Value    | 57     | 66  | 10      | Transaction value in cents     |
| Seller   | 67     | 86  | 20      | Seller's name                  |

### Transaction Types


These are the possible values for the Type field:

| Tipo | Descrição           | Natureza | Sinal |
| ---- | ------------------- | -------- | ----- |
| 1    | Producer Sale	     | Income   | +     |
| 2    | Affiliate Sale      | Income   | +     |
| 3    | Paid Commission     | Expense  | -     |
| 4    | Received Commission | Income   | +     |

## Evaluation

Seu projeto será avaliado de acordo com os seguintes critérios:

1. Documentação do setup do ambiente e execução que rode a aplicação com
   sucesso.
2. Cumprimento dos [requisitos funcionais](#Requisitos-Funcionais) e
   [não funcionais](#Requisitos-Nao-Funcionais).
3. Boa estruturação do componentes e layout de código, mas sem over engineering.
3. Legibilidade do código.
4. Boa cobertura de testes.
5. Claridade e extensão da documentação.
6. Cumprimento de algum [requisito bônus](#Requisitos-Bonus).

Your project will be evaluated based on the following criteria:

1. Documentation of environment setup and execution that successfully runs the application.
2. Fulfillment of [functional requirements](#Functional Requirements) e
   [non-functional requirements](#Non-Functional Requirements).
3. Proper structuring of components and code layout, without overengineering.
4. Code readability.
5. Good test coverage.
6. Clarity and extent of documentation.
7. Fulfillment of any bonus requirement.

## Repository Readme

- Should include the project title.
- A one-sentence description of the project.
- A list of used languages, frameworks, and/or technologies.
- Installation and usage instructions.
- Don't forget the .gitignore file.
- If using a personal GitHub account, reference that it's a challenge by Coodesh:  

>  This is a challenge by [Coodesh](https://coodesh.com/)

## Submission and Presentation Instructions

Notify about the completion and submit for review.

1. Check if you've answered the Scorecard attached to the position you've applied for.
2. Check if you've answered the Mapping attached to the position you've applied for.
3. Access https://coodesh.com/challenges/review.
4. Add the repository with your solution.
5. Record a video, using the button on the Coodesh review request screen, lasting no more than 5 minutes, presenting your project. Use the time to:

- Explain the challenge's objective.
- Mention the technologies used.
- Show the application in action.
- Focus on mandatory points and differentials during the presentation.

6. Add the link to the presentation video in the README.md.
7. Ensure the Readme is in good shape and make the final commit to your repository.
8. Check the desired position.
9. Send and wait for further instructions. Success and good luck. =)


## Support

Use [our community](https://discord.gg/rdXbEvjsWu) to ask questions about the process or send a message directly to an expert through the platform's chat.

