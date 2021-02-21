//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace examuser
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class uss
    {
        public int Id_u { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "От 2 до 20")]
        [RegularExpression("[А-ЯЁ]{1}[а-яё]{1,29}", ErrorMessage = "Некорректно С большой и кирилицой")]
        public string loginuser { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "От 2 до 30")]
        //[RegularExpression("[А-Яа-яЁё]+", ErrorMessage = "Некорректно")]
        [RegularExpression("[А-ЯЁ]{1}[а-яё]{1,29}", ErrorMessage = "С большой и кирилицой")]
        public string lattnameuser { get; set; }

        [Display(Name = "Почта")]
        [Index(IsUnique = true)]
        [StringLength(450)]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}", ErrorMessage = "Некорректный адрес")]
        [RegularExpression(@"(?<name>[\w.]+)\@(?<domain>\w+\.\w+)(\.\w+)?", ErrorMessage = "Некорректный адрес")]
        public string email { get; set; }
       

            [Display(Name = "Телефон")]
[Index(IsUnique = true)]
[StringLength(450)]
[Required(ErrorMessage = "Поле должно быть заполнено")]
//[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}", ErrorMessage = "Некорректный адрес")]
[RegularExpression(@"(^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$)", ErrorMessage = "Некорректный nomer")]

public string phone { get; set; }
//true, "555-5555-555"
//true, "+48 504 203 260"
//true, "+48 (12) 504 203 260"
//true, "+48 (12) 504-203-260"
//true, "+48(12)504203260"
//true, "+4812504203260"
//true, "4812504203260



        [Display(Name = "Дата")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime dateordered { get; set; }
    }
}
