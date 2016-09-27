# Practice Chinook
This repository is to practice coding **Entities**, **DTOs**, and **POCOs** within a Visual Studio solution. The Visual Studio solution has a  E**Website**, and two **Class Library** projects: `ChinookSystem` and `ChinookSystem.Data`.

## ChinookSystem
This class library project has two folders, **BLL** and **DAL**.

## ChinookSystem.Data
This class library project has three folders **Entities**, **DTOs** and **POCOs**.

### Entities
The classes in this folder directly relate to tables in the Chinook database. Each class will include the annotaions from the `System.ComponentModel.Annotations` and `System.ComponentModel.??`

### POCOs
The classes in this folder are _flat_ files and represent LINQ queries using anonymous data types.

### DTOs
The classes in this folder contain a _master-detail_ style of data.
