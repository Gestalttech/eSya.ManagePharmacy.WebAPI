using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSya.ManagePharmacy.DO;

namespace eSya.ManagePharmacy.IF
{
    public interface ICommonRepository
    {
        Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType);
        Task<List<DO_DrugComposition>> GetComposition(); 
        Task<List<DO_DrugComposition>> GetDrugFormulation(int CompositionId); 
        Task<List<DO_DrugComposition>> GetManufacturers(int CompositionId, int FormulationID);
        Task<List<DO_CountryCodes>> GetISDCodes();
    }
}
