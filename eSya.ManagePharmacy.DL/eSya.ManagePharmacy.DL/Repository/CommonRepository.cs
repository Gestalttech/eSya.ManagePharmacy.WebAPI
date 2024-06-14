using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSya.ManagePharmacy.DL.Entities;
using eSya.ManagePharmacy.DO;
using eSya.ManagePharmacy.IF;

namespace eSya.ManagePharmacy.DL.Repository
{
    public class CommonRepository : ICommonRepository
    {
        public static string GetValidationMessageFromException(DbUpdateException ex)
        {
            string msg = ex.InnerException == null ? ex.ToString() : ex.InnerException.Message;

            if (msg.LastIndexOf(',') == msg.Length - 1)
                msg = msg.Remove(msg.LastIndexOf(','));
            return msg;
        }

        public async Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcapcds
                        .Where(w => w.CodeType == codeType && w.ActiveStatus)
                        .Select(r => new DO_ApplicationCodes
                        {
                            ApplicationCode = r.ApplicationCode,
                            CodeDesc = r.CodeDesc
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DrugComposition>> GetComposition()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEphdrcs
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_DrugComposition
                        {
                            CompositionId = r.CompositionId,
                            DrugCompDesc = r.DrugCompDesc
                        }).OrderBy(o => o.DrugCompDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DrugComposition>> GetDrugFormulation(int CompositionId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEphdfrs
                        .Where(w => w.CompositionId == CompositionId && w.ActiveStatus)
                        .Select(r => new DO_DrugComposition
                        {
                            FormulationID = r.FormulationId,
                            FormulationDesc = r.FormulationDesc
                        }).OrderBy(o => o.FormulationDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DrugComposition>> GetManufacturers(int CompositionId, int FormulationID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEphdfms
                        .Where(w => w.ActiveStatus && w.CompositionId == CompositionId && w.FormulationId == FormulationID)
                        .Join(db.GtEphmnfs.Where(K => K.ActiveStatus),
                    a => new { a.ManufacturerId },
                    b => new { b.ManufacturerId },
                    (a, b) => new { a, b })
                        .Select(r => new DO_DrugComposition
                        {
                            ManufacturerId = r.a.ManufacturerId,
                            ManufacturerName = r.b.ManufacturerName
                        }).OrderBy(o => o.ManufacturerName).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_CountryCodes>> GetISDCodes()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEccncds
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_CountryCodes
                        {
                            Isdcode = r.Isdcode,
                            CountryName = r.CountryName
                        }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_BusinessLocation>> GetBusinessKey()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEcbslns
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.BusinessKey,
                            LocationDescription = r.BusinessName + " - " + r.LocationDescription
                        }).ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DrugComposition>> GetManufacturersList()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var mf = db.GtEphmnfs
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_DrugComposition
                        {
                            ManufacturerId = r.ManufacturerId,
                            ManufacturerName = r.ManufacturerName
                        }).OrderBy(o => o.ManufacturerName).ToListAsync();

                    return await mf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
