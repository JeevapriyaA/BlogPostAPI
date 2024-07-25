** Blog Post Application **

** SetUp Instructions:

### Prerequisites

   - .NET 7.0 SDK
   - Visual Studio Code (or any preferred IDE)

### Installation

1. Clone the repository:
  
   git clone (https://github.com/JeevapriyaA/BlogPostAPI/tree/main)
   
   cd BlogPostAPI

2.Backend setup:

  cd BlogPostAPI
  
  dotnet restore

** How to Run the Application:

1.Start the backend server:

   cd ../BlogPostAPI
   
   dotnet run

** Design Decisions and Application Structure:

 ### Backend (.NET Core)
	Framework: .NET Core 7.0
	Data Storage: Local JSON file as mock database
	Error Handling: Global error handling for consistent error responses
	CRUD Operations: RESTful APIs for Create, Read, Update, Delete blog posts

** Folder Structure :

backend :

BlogPostAPI Layer:

         Controllers/BlogPostController.cs

BlogPost.Repository Layer:

         Interface/IBlogPostRepository.cs

         ../BlogPostRepository.cs

BlogPost.Model Layer:

         DTO/BlogPostDto.cs

	 ../Blog.cs

BlogPost.Common Layer:

         ../CustomExceptionMiddleware.cs

BlogPost.UnitTest Layer:

         ../BlogPostUnitTest.cs


Performance Considerations:

Provide a brief explanation of how the application could scale with a large number of blog posts and how the current design supports scalability.


Database Design and Performance:

Database Indexing: Ensure that the database used (e.g., SQL Server, PostgreSQL) is properly indexed on frequently queried fields.

Backend API Performance :

Caching: Implement caching mechanisms (e.g., in-memory caching) to store frequently accessed blog posts instead of getting from database.

Asynchronous Processing: Use asynchronous programming techniques (e.g., async/await in C#).

Monitoring and Optimization:

Performance Monitoring: Implement monitoring tools (e.g., Application Insights) to track application performance such as errors,logging.

Scalable Architecture Design :

Microservices Architecture: Consider breaking down the application into smaller, independent services that can be used independently based on demand.

	 
