# JSONPlaceholder Proxy API Demo

This project demonstrates a simple ASP.NET Core Web API controller acting as a proxy for interacting with JSONPlaceholder's posts data.

## Functionality

- **GET /api/Post/GetPostById/{id}** - Retrieves a specific post by its ID
- **POST /api/Post/CreatePost** - Creates a new post (note: JSONPlaceholder might not fully support this)
- **PUT /api/Post/EditExistingPost/{id}** - Updates an existing post by ID (note: JSONPlaceholder might not fully support this)
- **DELETE /api/Post/DeletePost/{id}** - Deletes a post by ID (note: JSONPlaceholder might not fully support this)
- **GET /api/Post/GetAllPost** - Fetches a list of all posts

## Prerequisites

- .NET Core (Version might be needed)
- ASP.NET Core Web API project

## Setup

1. Clone this repository.
2. Open the project in your IDE or code editor.
3. Run the web application.

## Usage (Example)

Replace localhost:5000 (or the relevant port) with the base URL where your application is running:

```http
GET http://localhost:5000/api/Post/GetPostById/1 
