# Student Management System - CQRS and Mediator API

This project implements a fully functional Student Management System API demonstrating the **Command Query Responsibility Segregation (CQRS)** and **Mediator patterns** using MediatR in ASP.NET Core (.NET 8.0). All data is stored in memory.

## 1. Project Overview

The core purpose of this application is to strictly **decouple read operations (Queries) from write operations (Commands)**, enhancing maintainability, scalability, and testability.

* **Functionality:** Full CRUD (Create, Retrieve, Update, Delete) support for Student records.
* **Data Store:** Data persists only in memory (static `List<Student>`) within the `StudentStore.cs` class.

## 2. Architectural Components

| Component | Technology | Purpose in This Project |
| :--- | :--- | :--- |
| **Routing Layer** | **Carter (Modular API)** | Defines the HTTP endpoints and sends requests via the Mediator. |
| **Mediator** | **MediatR** | Decouples the routing layer from the business logic. |
| **Commands** | **MediatR Requests** | Handles all state-changing operations (POST, PUT, DELETE) in dedicated **Command Handlers**. |
| **Queries** | **MediatR Requests** | Handles all data retrieval operations (GET) in dedicated **Query Handlers**. |

## 3. How to Run the Project

1.  **Open Solution:** Open the **`StudentCQRSLab.sln`** file in Visual Studio.
2.  **Build:** Build the solution to restore all dependencies (Carter, MediatR).
3.  **Run:** Start the project (Press **F5** or click the Run button).
4.  **Access API:** Open the Swagger UI in your browser (e.g., `https://localhost:XXXX/swagger`).

## 4. Testing & Verification (Data Lifecycle Audit)

The successful operation of the entire CQRS pipeline has been verified through a full **Data Lifecycle Audit**.

* **Evidence Location:** All 12 sequential verification screenshots are contained within the **`Submission_Screenshots`** folder.
* **Audit Trail Summary:** The tests confirm that every **Command** (e.g., `02A_POST_COMMAND_REQUEST`) successfully modifies the data, which is immediately verified by a subsequent **Query** (e.g., `03B_GET_VerifyAdd_RESPONSE`), and ultimately removed by the `DELETE` command.

**Example Verification Files:**

| Step | Action | Confirmation File |
| :--- | :--- | :--- |
| **Create (POST)** | Shows successful creation of the new student (ID 5). | `02B_POST_COMMAND_RESPONSE.png` |
| **Verify Persistence** | Shows actual data fetched for ID 5 after creation. | `03B_GET_VerifyAdd_RESPONSE.png` |
| **Verify Update** | Shows the entire list containing the updated name after the PUT command. | `05A_GET_VerifyUpdate_STATE.png` |
| **Final State** | Confirms ID 5 is permanently removed from the list. | `07_GET_Final_State.png` |