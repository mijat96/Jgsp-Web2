export class Osoba{
    name: string
    surname: string
    
}

export class User{
    username: string
    password: string
}

export class RegUser{
    name: string
    surname: string
    username: string
    password: string
    confirmPassword: string
    email: string
    date: string
}

export class raspored {
    polasci : string

}
export class linja {

    linije : number[]
}
export class klasaPodaci{
    id : number
    dan : string
}
export class Profil {
    Tip : string 
   Datum : string
   Password : string
    Name : string
    Surname : string
    ConfirmPassword : string
    UserName : string 
    Email : string
}
export class CenovnikBindingModel {
   mesecna : number
    godisnja : number
  vremenska : number
    dnevna : number
  vaziDo : string
    vaziOd: string
    popustPenzija : number
    popustStudent : number
    id : number
}
export class RedVoznje {
    dan: string
    polasci: string
    linija : string
}