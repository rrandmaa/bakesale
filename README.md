# Bakesale

## Running the project

To run this project locally:
- in the root directory of the repository, run ``docker compose up -d`` (backend, database)
- in the /frontend directory, run ``npm run dev`` (frontend)

Going to the port specified by the latter command, you can see the running project.

Running the backend in development mode, say, in Visual Studio, behaves a little diferently than when using ``docker compose``.
- In memory database is used
- Swagger documentation is put up on the default port

## Technologies used

Frontend: Vue3 with Vite
Backend: .NET6 ASP.NET Web API, Entity Framework
Database: Postgres

## About the project

This project is an application meant to help run a bake sale and second hand shop for a charity event. You can read the specifics in the /docs folder from the prompt.

I've decided to go a little further than the prompt requires on the initial look. To me, reusability and future value propositions are important qualities of software, so I approached this application like a product.

The flow of using this application for running your sale goes as follows:
- You reach the home page
- Greeted by the **New sale** button, you click on it and a form appears with prefilled data (loaded in from a configuration file from /frontend/src/assets/products.json)
- The data that is not prefilled must now be filled in: the name of the sale and the prices of the second-hand items
- Clicking **Register sale** (or pressing enter) should land you back on the main page if everything went successfully
- Now, seeing the new registered sale, you can click on **Go to sale**
- From there you can **Start a new order**
- Now you can constuct your order, following the requirements in the propmt
- Clicking **checkout** opens up a modal with a tool to calculate the cash return and a list of products in the order
- **Complete purchase** sends the purchase to the backend and navigates you to the sale's home page, where you can start a new order

Given the application is used simultaneously by multiple sales-persons on mobile devices, the following choices were made:
- Using bootstrap as the UI library allowed for out-of-the box responsive design, everything should look great on phones and tablets
- Concurrency is handled by the design of the domain model, but the stock data is also refreshed when **starting a new order**, pressing **checkout** and also validated a final time when posting the purchase resource
- When running out of stock during constructing an order, feedback is given to the user via grayed-out images, but also when checking out, the list of products displays out-of-stock product lines with red, along with an error message

A diagram of the domain model can be found in the docs directory.

The backend also comes with a project for unit tests. Currently the repository layer and a few domain objects containing business logic are covered with these unit tests.

Feel free to browse the git history here, the application went through a few phases in the development cycle (even had a default dark theme in the UI at some point).

## Future developments

Here, I'll leave a list of things I consider as too out-of-scope for this trial run, but what I would implement if this was an actual product:
- Either *Postman* tests, or controller unit tests for the API
- *Cypress* E2E tests for the frontend
- Sale home page should have a list of purchases with useful data like purchase date-time and total purchase price
- Images should ideally be stored in the database as blobs, the current solution with paths to frontend assets is a quick-and-easy one
