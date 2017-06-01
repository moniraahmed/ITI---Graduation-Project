using AutoMapper;
using ITI.Business.Map;
using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business
{
   public class ComplaintManager: DataRepositoy<ITIEntities,Student_Complaints>
    {
        public IEnumerable<Student_ComplaintsMap> GetAllComplaints()
        {
            var x = GetAll().ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(x);
         
        }

        public void AddComplaint(Student_Complaints newcomplaint)
        {
            Add(newcomplaint);
        }
        //return all compliants for students
        public IEnumerable<Student_ComplaintsMap> GetStudentComplaints(int st_id)
        {
            var comp= FindBy(a => a.FK_Student_Id == st_id).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
         
        }

        //return all students compliants at stage one
        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatStageOne(int st_id)
        {
            var comp = FindBy(a => a.FK_Student_Id == st_id &&a.CurrentStage==1 &&a.FK_Category_Id==1).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
     
        }
        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatStageTwo(int st_id)
        {
            var comp = FindBy(a => a.FK_Student_Id == st_id && a.CurrentStage == 2&&a.FK_Category_Id==1).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
        }
        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatStageThree(int st_id)
        {
            var comp = FindBy(a => a.FK_Student_Id == st_id && a.CurrentStage == 3 && a.FK_Category_Id == 1).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
        }

        //public Student_ComplaintsMap GetStudentComplaintsatStageThree1(int c_id)
        //{
        //    var comp =FindBy(a => a.ID== c_id && a.CurrentStage == 3 && a.FK_Category_Id == 1);
        //    return Mapper.Map(comp);
        //}


        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatStageFour(int st_id)
        {
            var comp = FindBy(a => a.FK_Student_Id == st_id && a.CurrentStage == 4 && a.FK_Category_Id == 1).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
        }

        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatBeforeStageTwo(int st_id)
        {
            var comp = FindBy(a => a.FK_Student_Id == st_id && a.CurrentStage == 1 && a.FK_Category_Id == 1).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
        }


        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatBeforeStageThree()
        {
            var comp = FindBy(a => a.CurrentStage < 3 && a.FK_Category_Id == 1).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
        }


        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatBeforeStageFour()
        {
            var comp = FindBy(a => a.CurrentStage < 4 && a.FK_Category_Id==1).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
        }
        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatAllStages()
        {
            var x = GetAll().ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(x);
        }


    }
}
