# BugTracker
Build a small realistic application using .Net 9 and Angular 16

## Prerequisites

- [Docker](https://docs.docker.com/get-docker/) installed and running on your machine.
- (Optional) Docker Compose (usually comes with Docker Desktop).

---

## How to Run the Application with Docker
```bash
### 1. Clone the Repository

git clone https://github.com/El-Makhroubi-Mohammed/BugTracker.git
cd BugTracker

### 2. Start the application:

Run the following command to build the Docker image(s) and start the container(s):

docker compose up --build

### 3. Access the application:

The application should now be running at http://localhost:4200

You can then access the backend API at http://localhost:5000/swagger

### 4. To stop the application:

docker compose down


