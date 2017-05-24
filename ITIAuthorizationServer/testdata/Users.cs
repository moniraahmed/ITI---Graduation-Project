/*
 * Copyright 2014 Dominick Baier, Brock Allen
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ITIAuthorizationServer
{
    static class Users
    {
        public static List<User> Get()
        {
            var users = new List<User>
            {
                new User{ BranchID=1, EmployeeID=1206,InstructorName="emp1",IPassword="demo1",UserName2="demo1"}
                ,
             new User{ BranchID = 1, EmployeeID = 1043, InstructorName = "emp2", IPassword = "demo2", UserName2 = "demo2" } ,
                new User{ BranchID = 1, EmployeeID = 1319, InstructorName = "emp3", IPassword = "demo3", UserName2 = "demo3" } ,
            };
            return users;
           
        }
    }
    static class Students
    {
        public static List<Student> Get()
        {
            var Student = new List<Student>
            {
                new Student{ BranchID=101, StudentID=8088,englishname="Student1",IPassword="demo1",UserName2="demo1",TrackID =376}
                ,
             new Student{ BranchID = 1, StudentID = 7488, englishname = "Student2", IPassword = "demo2", UserName2 = "demo2",TrackID =318 } ,
                new Student{ BranchID = 1, StudentID = 7298, englishname = "Student3", IPassword = "demo3", UserName2 = "demo3",TrackID =333 } ,
            };
            return Student;

        }
    }
    static class Companys
    {
        public static List<Company> Get()
        {
            var Company = new List<Company>
            {
                new Company{ CompanyID=6, CompanyApprove=true,CompanyName="Company1",CompanyPassWord="demo1",CompanyUserName="demo1"}
                ,
             new Company{ CompanyID = 4, CompanyApprove = true, CompanyName = "Company2", CompanyPassWord = "demo2", CompanyUserName = "demo2" } ,
                new Company{ CompanyID = 9, CompanyApprove = false, CompanyName = "Company3", CompanyPassWord = "demo3", CompanyUserName = "demo3" } ,
            };
            return Company;

        }
    }
    public partial class User
    {
        public int EmployeeID { get; set; }
        public string InstructorName { get; set; }
        public int BranchID { get; set; }
        public string IPassword { get; set; }
        public string UserName2 { get; set; }
            }
    public partial class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public bool CompanyApprove { get; set; }
        public string CompanyUserName { get; set; }
        public string CompanyPassWord { get; set; }
    }
    public partial class Student
    {
        public int StudentID { get; set; }
        public string englishname { get; set; }
        public int TrackID { get; set; }
        public int BranchID { get; set; }
        public string IPassword { get; set; }
        public string UserName2 { get; set; }
    }
}