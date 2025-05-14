# Agri Energy Connect Platform

## Overview
- **Name:** Troy Krause
- **Student Number:** ST10248581
- **Github:** https://github.com/ST10248581/AgriEnergy

The Agri Energy Connect Platform is a web application built with ASP.NET MVC that allows employees to manage farmer data and their products. Farmers can also add their own products, while employees can view and filter those products. The platform aims to create a connection between farmers and potential consumers or buyers by providing a seamless way to manage and showcase products.

## Features

* **Employee Features:**

  * Add and manage farmer details.
  * View a list of farmers.
  * Filter and view farmer products by category, name, and more.

* **Farmer Features:**

  * Add and manage their own products.
  * View their products and product details.

* **Common Features:**

  * All Products Page: A centralized page for employees and farmers to view all available products.
  * Product Filtering: Allow filtering of products based on various attributes like category, price, and availability.

## Requirements

* .NET 8 or later 
* Microsoft SQL Server
* Visual Studio (IDE that supports ASP.NET MVC development)
* Browser for accessing the platform

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/ST10248581/AgriEnergy
   cd AgriEnergyConnect
   ```

2. Restore the project dependencies:

   ```bash
   dotnet restore
   ```

3. Set up the database by running the scripts provided in the project folder in Microsoft SQL Server (SQL Scrips).
4. Run the application:

   ```bash
   dotnet run
   ```

5. Open a browser and go to the URL shown in your terminal to access the platform.

## Database Structure

The platform uses the following tables:

* **Farmers**: Stores information about farmers. Farmers are users andf have a 'UserId'.
* **Products**: Stores details about the products offered by farmers, such as product name, category, description, and price.
* **Users**: Stores user details who access the platform.
* **UserRoles**: Stores user roles that determine which features a user may access (e.g. Employee, Farmer).

## Usage

### Employee Features

* **Add Farmer**: Navigate to the "Add Farmer" page (under the 'Employee' drop down) to add a new farmer, providing their details like name, contact info, and other relevant data.
* **View Farmers**: View a list of all farmers in the platform (under the 'Employee' drop down). Each entry will link to the farmer’s products.
* **Filter Products**: Use the filters available to narrow down products by category, name, and other parameters.

### Farmer Features

* **Add Product**: Farmers can add their products through the "Add Product" page (Under the 'Farmer' drop down) They’ll need to provide details like product name, description, price, and type.
* **View All Products**: This (Under the 'Farmer' drop down) page provides a comprehensive view of all products across the platform.

## Technologies Used

* **ASP.NET Core MVC**: The core framework for building the web application.
* **Entity Framework Core**: ORM for database interactions.
* **SQL Server**: The database for storing farmer and product data.
---
