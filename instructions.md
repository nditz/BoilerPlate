// I want to create a backend using .Net Core with clean architecture approach that follows the guideline from https://github.com/ardalis/CleanArchitecture.
// In this setup I will want to use flyway to manage the database changes and not use migrations. I would like the project to use use this structure layers
// Domain, Application, Infrastructure, Persistence, WebAPI, SharedKernel.

//⛳ GOAL: Design a flexible hybrid RBAC + ABAC model using EF Core
// 🎯 Context:  multi-tenant system with hierarchy:
// Organization > Office > Location > Department

// 🔁 Hybrid Access Control (RBAC + ABAC):
// - Users can be internal (staff) or external (customer/patient)
// - Staff may belong to multiple departments with different responsibilities
// - Roles define access (view, edit, assign, etc.), Permissions are granular
// - ABAC enforced through relationships like "assignedTo" or "ownership"

// 🔧 Requirements:
// 1. Create enums and base models:
//    - enum UserType { Internal = 0, External = 1 }
//    - class User { Guid Id, string Username, UserType Type, ... }

// 2. Define hierarchy:
//    - Organization -> Offices -> Locations -> Departments

// 3. Staff Structure:
//    - class StaffType { Guid Id, string Name, string Description }
//    - A staff user can be in multiple departments with different roles

// 4. Roles & Permissions:
//    - class Role { Guid Id, string Name }
//    - class Permission { Guid Id, string Name }
//    - class RolePermission { RoleId, PermissionId }
//    - class UserRole { UserId, RoleId, optional DepartmentId }

// 5. ABAC Relations:
//    - class UserAssignment { ExternalUserId, InternalUserId } // staff-customer mapping

// 6. Generate DbContext with DbSets and Fluent API constraints
// 7. Ensure enums are stored as int (UserType), with conversions if needed

// Please generate the full EF Core models and DbContext for this setup.
