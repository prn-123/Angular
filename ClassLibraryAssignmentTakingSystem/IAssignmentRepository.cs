using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAssignmentTakingSystem
{
    interface IAssignmentRepository
    {
        List<Assignment> GetAssignment();
        Assignment FindAssignment(int AssignmentId);
        void Insert(Assignment a);
    }
}
