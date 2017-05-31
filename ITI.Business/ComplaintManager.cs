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
            var comp = FindBy(a => a.FK_Student_Id == st_id &&a.CurrentStage==1).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
     
        }
        public IEnumerable<Student_ComplaintsMap> GetStudentComplaintsatStageTwo(int st_id)
        {
            var comp = FindBy(a => a.FK_Student_Id == st_id && a.CurrentStage == 2).ToList();
            return Mapper.Map<IEnumerable<Student_ComplaintsMap>>(comp);
        }
    }
}
