# Bakesale

## Running the project

To run this project locally:
- in the root directory of the repository, run ``docker compose up -d`` (backend, database)
- in the /frontend directory, run ``npm run dev`` (frontend)

Going to the port specified by the latter command, you can see the running project.

Running the backend in development mode, say, in Visual Studio, behaves a little diferently than when using ``docker compose``.
- In memory database is used
- Swagger documentation is put up on the default port
