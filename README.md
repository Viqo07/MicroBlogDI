# MicroBlogDI

## Overview

MicroBlogDI is a simple ASP.NET Core Razor Pages blog application that uses the Repository Pattern and Dependency Injection.

The application allows users to create, view, edit, and delete blog posts.

## Repository Pattern

This project uses the `IBlogRepository` interface so that the application can switch between different repository implementations.

There are two repository implementations:

* `JsonBlogRepository` — saves posts to `data/posts.json`.
* `InMemoryBlogRepository` — stores posts in memory while the application is running.

## Dependency Injection

The repository is registered in `Program.cs`.

### Using the JSON Repository

The application currently uses the JSON repository:

```csharp
builder.Services.AddSingleton<IBlogRepository, JsonBlogRepository>();
```

Posts are saved to:

```text
data/posts.json
```

Because the posts are saved to a JSON file, they remain available after the application is restarted.

### Switching to the In-Memory Repository

To switch to the in-memory repository, change the registration in `Program.cs` to:

```csharp
builder.Services.AddSingleton<IBlogRepository, InMemoryBlogRepository>();
```

The rest of the application does not need to be changed because the Razor Pages use the `IBlogRepository` interface.

Posts created with the in-memory repository are only stored while the application is running. They disappear when the application is stopped and restarted.

## How to Run

Open a terminal in the project folder and run:

```powershell
dotnet run
```

Then open the URL shown in the terminal, such as:

```text
http://localhost:5143
```

## Features

* Create blog posts
* View blog posts
* Edit blog posts
* Delete blog posts
* JSON file storage
* In-memory storage
* Repository Pattern
* Dependency Injection
* Razor Pages
