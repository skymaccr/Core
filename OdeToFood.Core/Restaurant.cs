using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{

    public class Restaurant //: IValidatableObject
    {
        public int Id { get; set; }

        //estos son mapeos que se utilizan para las validaciones y para la creacion de las migraciones
        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }
        public CousineType Cousine { get; set; }

        //por medio de este modelo se puede decir si un modelo es valido o no
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
