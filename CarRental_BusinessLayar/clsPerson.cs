using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental_DataAccessLayar;


namespace CarRental_BusinessLayar
{
    public class clsPerson
    {
        public PersonDTO PersonDTO
        {
            get
            {
                return new PersonDTO(this.ID, this.NationalNo, this.FirstName, this.SecondName,
                    this.ThirdName, this.LastName, this.DateOfBirth,
                    this.Gendor, this.Phone, this.Email);
            }
        }
        public int ID { get; set; }


        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte Gendor { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }





        public string FullName
        {
            get
            {

                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }
        public string GenderCaption
        {
            get
            {
                switch ((enGender)Gendor)
                {
                    case enGender.Male:
                        return "Male";
                    default:
                        return "Femail";
                }
            }
        }
        public enum enGender
        {
            Male = 0,
            Female = 1
        }
        public enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;
        public clsPerson()
        {
            ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gendor = 1;
            Phone = string.Empty;
            Email = string.Empty;



            _Mode = enMode.AddNew;

        }

        private clsPerson(PersonDTO PDTO, enMode cMode = enMode.AddNew)
        {
            this.ID = PDTO.PersonID;
            this.NationalNo = PDTO.NationalNo;
            this.FirstName = PDTO.FirstName;
            this.SecondName = PDTO.SecondName;
            this.ThirdName = PDTO.ThirdName;
            this.LastName = PDTO.LastName;
            this.DateOfBirth = PDTO.DateOfBirth;
            this.Gendor = PDTO.Gendor;
            this.Phone = PDTO.Phone;
            this.Email = PDTO.Email;

            _Mode = cMode;

        }

        public static clsPerson FindPersonByID(int PersonID)
        {

           
            PersonDTO PDTO = clsPersonData.FindPersonByID(PersonID);
            if (PDTO != null)
            {
                return new clsPerson(PDTO, enMode.Update);
            }
            else { return null; }
        }

        public static clsPerson FindPersonByNationalNo(string NationalNo)
        {


            PersonDTO PDTO = clsPersonData.FindPersonByNationalNo(NationalNo);
            if (PDTO !=null)
            {
                return new clsPerson(PDTO,enMode.Update);
            }
            else { return null; }
        }

        public static DataTable PeopleList()
        {

            return clsPersonData.GetPeopleList();
        }


        bool _AddNew()
        {
            this.ID = clsPersonData.AddNewPerson(PersonDTO);

            return this.ID != -1;


        }
        bool _Update()
        {
            return clsPersonData.UpdatePerson(PersonDTO);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();


            }
            return false;
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);

        }


        public static bool IsPersonExistsByPersonID(int PersonID)
        {
            return clsPersonData.IsPersonExistsByPersonID(PersonID);
        }
        public static bool IsPersonExistsByNationalNo(string NationalNo)
        {
            return clsPersonData.IsPersonExistsByNationalNo(NationalNo);
        }



    }
}
