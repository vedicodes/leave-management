# Leave Management System

**Requirements Specification**

---

## Business Use Case

Design & Develop a Backend System for an Employee Leave Management Portal.  
The system allows employees to apply for leaves, managers to approve/reject leave requests, and provides visibility into leave balances and history.

---

## User Flow

### 1. Login

- Pre-defined users (Employees & Managers) should be able to log in
- Users have roles: Employee or Manager
- Implement JWT-based authentication:
  - Generate JWT token on successful login
  - Token should contain `userId`, `role`, and expiration
  - All subsequent API calls must include JWT token in `Authorization` header
  - Validate JWT token for protected endpoints
- Implement role-based authorization:
  - Employees can only access their own data
  - Managers can access their team members' data
  - Enforce authorization checks on all endpoints

### 2. View Leave Balance

- Employees can view their current leave balances by leave type
- Display available leaves for: Sick Leave, Casual Leave, Privilege Leave, etc.
- Show total allocated, used, and remaining leaves

### 3. Apply for Leave

- Employees can apply for leave by specifying:
  - Leave Type (Sick, Casual, Privilege, etc.)
  - Start Date & End Date
  - Number of days
  - Reason
  - Reporting Manager
- Backend validations:
  - Check if employee has sufficient leave balance
  - Check for overlapping leave requests
  - Validate date ranges (no past dates, start ≤ end)
- Leave status is set to: **Pending** upon successful submission

### 4. View Leave Requests (Manager)

- Managers can view all pending leave requests for their team members
- Filter by: Status (Pending/Approved/Rejected), Employee, Date Range
- Display leave details with employee information

### 5. Approve / Reject Leave

- Managers can approve or reject pending leave requests
- On approval:
  - Deduct leave balance from employee's account
  - Update leave status to Approved
  - Trigger notification to employee
- On rejection:
  - Update leave status to Rejected
  - Store rejection reason/comments
  - Trigger notification to employee

### 6. View Leave History

- Employees can view their leave history (All / Approved / Rejected / Pending / Cancelled)
- Support pagination and filtering

### 7. Notifications

- On successful leave application: log notification for employee and manager
- On approval: log notification to employee
- On rejection: log notification to employee with reason
- On system errors: log error messages

---

## Tools / Technologies

| Component            | Options                          | Recommended                          |
|----------------------|----------------------------------|--------------------------------------|
| Language             | Java / .NET / Python / NodeJS    | .NET Core (C#) or Java Spring Boot   |
| API Gateway          | .NET: Ocelot<br>Java: Spring Cloud Gateway | Ocelot (.NET)                 |
| Service Discovery    | Eureka (Netflix OSS) or Consul   | Consul or Eureka                    |
| Database             | In-memory / SQL / NoSQL          | In-memory (MVP) or PostgreSQL        |
| Message Broker       | RabbitMQ                         | RabbitMQ                             |
| Containerization     | Docker + Docker Compose          | Docker + Docker Compose              |

- All microservices register themselves with the discovery service
- Database is optional for MVP (in-memory collections or mock data stores)

---

## Cross-Cutting Concerns

- Logging
- Circuit Breaker Pattern
- Authentication & Authorization
- Global Exception Handling
- Distributed Tracing

---

## Focus

- Backend only — no front-end UI needed
- Implement JWT-based authentication and authorization (not mock)
- Notification via log entries (no real email/SMS integration)
- RESTful API guidelines with proper status codes & error messages
- Proper coding standards are followed

---

## Automatic Leave Allocation

When an employee is created, initialize leave balances:

| Leave Type       | Days     |
|------------------|----------|
| Casual Leave     | 12 days  |
| Sick Leave       | 10 days  |
| Privilege Leave  | 15 days  |

---

## Optional Enhancements (Bonus)

- Centralized logging with ELK Stack
- Health check endpoints for all services
