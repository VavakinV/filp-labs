open System
open System.Text.RegularExpressions

type DrivingLicense = {
    LastName: string
    FirstName: string
    MiddleName: string option
    BirthDate: DateTime
    BirthPlace: string
    IssueDate: DateTime
    ExpiryDate: DateTime
    IssuingDepartmentCode: string
    LicenseNumber: string
    Address: string
    VehicleCategories: string list
}

module DrivingLicense =
    let private nameRegex = Regex(@"^[А-ЯЁ][а-яё]+$", RegexOptions.Compiled)
    let private departmentCodeRegex = Regex(@"^ГИБДД \d{4}$", RegexOptions.Compiled)
    let private licenseNumberRegex = Regex(@"^\d{4}\d{6}$", RegexOptions.Compiled)

    let validateName fieldName value =
        if String.IsNullOrWhiteSpace(value) then
            Some (sprintf "%s не может быть пустым" fieldName)
        elif not (nameRegex.IsMatch(value)) then
            Some (sprintf "%s должно быть написано кириллицей с заглавной буквы" fieldName)
        else None

    let validateDepartmentCode code =
        if String.IsNullOrWhiteSpace(code) then
            Some "Код подразделения не может быть пустым"
        elif not (departmentCodeRegex.IsMatch(code)) then
            Some "Код подразделения должен быть в формате 'ГИБДД XXXX', где X - цифры"
        else None

    let validateLicenseNumber number =
        if String.IsNullOrWhiteSpace(number) then
            Some "Номер удостоверения не может быть пустым"
        elif not (licenseNumberRegex.IsMatch(number)) then
            Some "Номер удостоверения должен состоять из 10 цифр (4 серия + 6 номер)"
        else None

    let validate (license: DrivingLicense) =
        [
            validateName "Фамилия" license.LastName
            validateName "Имя" license.FirstName
            license.MiddleName |> Option.bind (fun m -> validateName "Отчество" m)
            validateDepartmentCode license.IssuingDepartmentCode
            validateLicenseNumber license.LicenseNumber
        ]
        |> List.choose id  

    let print (license: DrivingLicense) =
        Console.WriteLine("Водительское удостоверение")
        Console.WriteLine("Фамилия: {0}", license.LastName)
        Console.WriteLine("Имя: {0}", license.FirstName)
        Console.WriteLine("Отчество: {0}", license.MiddleName |> Option.defaultValue "Нет")
        Console.WriteLine("Дата и место рождения: {0}, {1}", license.BirthDate.ToShortDateString(), license.BirthPlace)
        Console.WriteLine("Дата выдачи: {0}", license.IssueDate.ToShortDateString())
        Console.WriteLine("Дата окончания срока действия: {0}", license.ExpiryDate.ToShortDateString())
        Console.WriteLine("Код подразделения: {0}", license.IssuingDepartmentCode)
        Console.WriteLine("Номер удостоверения: {0}", license.LicenseNumber)
        Console.WriteLine("Место жительства: {0}", license.Address)
        Console.WriteLine("Категории ТС: {0}", String.Join(", ", license.VehicleCategories))

    let compare (license1: DrivingLicense) (license2: DrivingLicense) =
        license1.LicenseNumber = license2.LicenseNumber

let exampleLicense = {
    LastName = "Иванов"
    FirstName = "Иван"
    MiddleName = Some "Иванович"
    BirthDate = DateTime(1990, 5, 15)
    BirthPlace = "г. Москва"
    IssueDate = DateTime(2020, 1, 10)
    ExpiryDate = DateTime(2030, 1, 10)
    IssuingDepartmentCode = "ГИБДД 0215"
    LicenseNumber = "1234567890"
    Address = "г. Москва, ул. Ленина, д. 1"
    VehicleCategories = ["B"; "C"]
}

let exampleLicense2 = {
    exampleLicense with
        LicenseNumber = "0987654321"
}

DrivingLicense.print exampleLicense

Console.WriteLine("\nСравнение документов: {0}", DrivingLicense.compare exampleLicense exampleLicense2)

let validationErrors = DrivingLicense.validate exampleLicense
if validationErrors.Length > 0 then
    Console.WriteLine("\nОшибки валидации:")
    validationErrors |> List.iter Console.WriteLine
else
    Console.WriteLine("\nДокумент валиден")