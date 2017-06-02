using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using AutoMapper;
using ITI.Business.Map;

namespace ITI.Business.Manager
{
    public class StudentManager : DataRepositoy<ITIEntities, StudentBasicData>
    {
        public IEnumerable<StudentBasicDataMap> GetStudent()
        {
            var x = GetAll().ToList();
            return Mapper.Map<IEnumerable<StudentBasicDataMap>>(x);
          //  var xx = new StudentManager().GetAll().ToList() ;
          //  return xx;

        }
        public StudentBasicDataMap GetStudent(int id)
        {
            var x = Get(id);
            return Mapper.Map<StudentBasicDataMap>(x);
            //  
            //var xx=  Mapper.Map <programMap> x();
            //  return  ;
        }
        public StudentBasicDataMap GetStudent(string username,string pass)
        {
            var x = FindobjBy(a=>a.Username == username);
            var re =  Mapper.Map<StudentBasicDataMap>(x);
            if (re.userpwd == pass)
            {
                return re;
            }
            else
            {
                return null;
            }
            
           
            
            //  
            //var xx=  Mapper.Map <programMap> x();
            //  return  ;
        }
        //platformintake table
        public IEnumerable<StudentBasicDataMap> GetStudentInSubtrack(int? platformintake)
        {
            var std = FindBy(a => a.SubTrackID == platformintake);
            return Mapper.Map<IEnumerable<StudentBasicDataMap>>(std);
        }


        public int GetSubtrackId(int st_id)
        {
            var std = FindobjBy(a => a.StudentID == st_id);
            return std.SubTrackID;
        }
    }
}
