using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ITI.Data.DBmodel;

namespace ITI.Business.Map
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<program, programMap>();
                cfg.CreateMap<programMap, program>();
                cfg.CreateMap<Intake, IntakeMap>();
                cfg.CreateMap<IntakeMap, Intake>();
                cfg.CreateMap<ProgramIntake, ProgramIntakeMap>();
                cfg.CreateMap<ProgramIntakeMap, ProgramIntake>();
                cfg.CreateMap<Branch, BranchMap>();
                cfg.CreateMap<BranchMap, Branch>();
                cfg.CreateMap<subTrack, subTrackMap>();
                cfg.CreateMap<subTrackMap, subTrack>();
                cfg.CreateMap<PlatfromIntake, PlatfromIntakeMap>();
                cfg.CreateMap<PlatfromIntakeMap, PlatfromIntake>();
                cfg.CreateMap<StudentBasicData, StudentBasicDataMap>();
                cfg.CreateMap<StudentBasicDataMap, StudentBasicData>();
                cfg.CreateMap<Course, CourseMap>();
                cfg.CreateMap<CourseMap, Course>();
                cfg.CreateMap<TrackManual, TrackManualMap>();
                cfg.CreateMap<TrackManualMap, TrackManual>();
                cfg.CreateMap<CourseManual, CourseManualMap>();
                cfg.CreateMap<CourseManualMap, CourseManual>();
                cfg.CreateMap<Employee, EmployeeMap>();
                cfg.CreateMap<EmployeeMap, Employee>();
            });

        }
    }
}

