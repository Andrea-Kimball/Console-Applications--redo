using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public class Claims_Repository
    {
        private List<Claims> _listOfClaims = new List<Claims>();

        //CREATE
        public void CreateClaim(Claims content)
        {
            _listOfClaims.Add(content);
        }

        //READ
        public List<Claims> ViewClaim()
        {
            return _listOfClaims;
        }

        //UPDATE
        public bool UpdateClaim(int id, Claims newClaim)
        {
            Claims original = GetClaimByID(id);
            if(original != null)
            {
                original.ClaimID = newClaim.ClaimID;
                original.Description = newClaim.Description;
                original.DateOfIncident = newClaim.DateOfIncident;
                original.DateOfClaim = newClaim.DateOfClaim;
                original.ClaimAmount = newClaim.ClaimAmount;
                original.ClaimType = newClaim.ClaimType;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool DeleteClaim(int claimId)
        {
            Claims item = GetClaimByID(claimId);
                if(item == null)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(item);
            if(initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //HELPER METHOD

        public Claims GetClaimByID(int claimId)
        {
            foreach(Claims item in _listOfClaims)
            {
                if(item.ClaimID == claimId)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
