#Job Application Tracker

	This is a simple web application built with ASP.NET Core Web API and React. The application allows user to manage job applications, add new application, update application status.

#Tech Stack

	.Backend: ASP.NET Core Web Api, Entity Framework Core, SQlite
	.Frontend: React, HTML/CSS
	.API communication: Axios

#How to run

	There are two projects in this solution, one for client and the other for server.
	.JobApplicationTracker.server is the backend
	.JobApplicationTracker.client is the fronend

	Prerequisites: Visual Studio IDE, .Net9.0, SQLite, Node.js

		1. Open solution: JobApplicationTracker.sln
		2. Hit F5 to run both client and backend.
			API will run at: https://localhost:7198
			React will run at: https://localhost:49831

#Features

	#Backend - ASP.NET Core Web API 
	.Restful API with following endpoints:
		GET/JobApplications - Retrive all job applications;
		GET/JobApplicaitons/{id} - Retrive a specific application;
		POST/JobApplications - Add a new application;
		PUT/JobApplicaitons - Update job application. e.g. update applicaiton status
	.User Entity Framework Core(Code first) with SQLite(database file can be found at root with name JobApplicationTracker.db. some testing records can be found when I test the frontend)
	.Repository pattern and Dependency Injection is used for separation of concerns
	.Swagger UI is available at: https://localhost:7198/swagger/index.html
	.Validation & Error handling: Ensures proper input validation. e.g. the button is diabled before both company name and postion are filled
 
 #Frontend - React
	.List all job applications in table
	.A form for adding new application
	.A dropdown next to each application to update status (Applied, Interview, Offer, Rejected)
	.Custom CSS style supporing responsive UI. (in App.css)

    
#Some assumptions

	.It is not a fully functional app with potential features. e.g. update company name/positin, delete application
	.Application status is one of Applied, Interview, Offer, Rejected, which are used for validation
	.CSS styles are simple just for demo purpose. potentially, we can use Bootstrap or tailwind properly
	.VS template is allowed to use for this testing

