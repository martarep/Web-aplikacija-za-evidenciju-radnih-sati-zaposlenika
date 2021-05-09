use PRA_RWA_Baza_Fin
go

create proc GetAktivniDjelatnici
as
begin
select * from Djelatnik
where Aktivan = 'Aktivan'
order by Ime,Prezime asc
end
go

create proc GetZaposlenici
as
begin
select * from Djelatnik
where Aktivan = 'Aktivan' and TipDjelatnikaID=3
order by Ime,Prezime asc
end
go



create proc UpdateDjelatnikTimId
@IDDjelatnik int,
@TimID int
as
begin

   if (@TimID=0)
   begin 
   update Djelatnik
   set
   TimID=null
   where IDDjelatnik=@IDDjelatnik
   end
   else
   begin
   update Djelatnik
   set
   TimID=@TimID
   where IDDjelatnik=@IDDjelatnik
   end
end
go

create proc UpdateTipDjelatika
@TimID int,
@IDDjelatnik int,
@TipDjelatnikaID int
as
begin
update Djelatnik
   SET 
TipDjelatnikaID =@TipDjelatnikaID,
TimID=@TimID
where IDDjelatnik=@IDDjelatnik
end
go

create proc UpdateTim
@IDTim int,
@Naziv nvarchar(50),
@DatumKreiranja date
as
begin
update Tim
   SET 
Naziv=@Naziv,DatumKreiranja=@DatumKreiranja
where IDTim=@IDTim
end
go

create proc InsertTim
@Naziv nvarchar(50),
@DatumKreiranja date
as
begin
insert Tim (Naziv, DatumKreiranja,Aktivan)
values (@Naziv,@DatumKreiranja, 'Aktivan')
end
go


create proc GetAktivniTimovi
as
begin
select * from Tim
where Aktivan = 'Aktivan'
order by Naziv asc
end
go

create proc GetSviTimovi
as
begin
select * from Tim
order by Naziv asc
end
go

create proc GetAktivnostTima
@IDTim int
as
begin
select * from Tim
where IDTim=@IDTim
end
go

create proc GetSviDjelatnici
as
begin
select * from Djelatnik
order by Ime,Prezime asc
end
go

create proc GetDjelatnik
@IDDjelatnik int
as
begin
select * from Djelatnik
where IDDjelatnik=@IDDjelatnik
end
go

create proc GetTipDjelatnika
@IDDjelatnik int
as
begin
select * from TipDjelatnika as td
inner join Djelatnik as d
on d.TipDjelatnikaID=td.IDTipDjelatnika
where IDDjelatnik= @IDDjelatnik
end
go

create proc GetTimDjelatnika
@IDDjelatnik int
as
begin
select * from Tim as t
inner join Djelatnik as d
on t.IDTim=d.TimID
where d.IDDjelatnik = @IDDjelatnik
end
go

create proc GetProjektiDjelatnika
@IDDjelatnik int
as
begin
select p.IDProjekt,p.Naziv,p.VoditeljProjektaID,p.Aktivan,p.DatumOtvaranja,p.KlijentID from Projekt as p
inner join ProjektDjelatnik as pd
on pd.ProjektID=p.IDProjekt
where pd.DjelatnikID=@IDDjelatnik
order by p.Naziv asc
end
go

create proc GetDjelatniciTima
@IDTim int
as
begin
select * from Djelatnik 
where TimID=@IDTim 
order by Ime,Prezime asc
end
go

create proc GetVoditeljTima
@IDTim int
as
begin
select * from Djelatnik 
where TimID=@IDTim and TipDjelatnikaID = 2
end
go


create proc GetTim
@IDTim int
as
begin
select * from Tim 
where IDTim=@IDTim
end
go


create proc GetAktivniProjekti
as
begin
select * from Projekt 
where Aktivan='Aktivan'
order by Naziv asc
end
go


create proc InsertProjektDjelatnik
@IDDjelatnik int, @IDProjekt int
as
begin
insert ProjektDjelatnik (ProjektID, DjelatnikID)
values (@IDProjekt,@IDDjelatnik)
end
go


create proc DeleteProjektDjelatnik
@IDDjelatnik int, @IDProjekt int
as
begin
delete from ProjektDjelatnik 
where ProjektID= @IDProjekt and DjelatnikID=@IDDjelatnik
end
go

create proc GetTipDjelatnikaID
@Naziv nvarchar(50)
as
begin
select * from TipDjelatnika
where Naziv = @Naziv
end
go

create proc GetTimID
@Naziv nvarchar(50)
as
begin
select * from Tim
where Naziv = @Naziv
end
go

create proc UpdateDjelatnik
@IDDjelatnik int,
@Ime nvarchar(50),
@Prezime nvarchar (50),
@Email  nvarchar (50),
@DatumZaposlenja date,
@Lozinka nvarchar(50),
@TipDjelatnikaID int,
@TimID int
as
begin
update Djelatnik
   SET Ime = @Ime,
Prezime = @Prezime,
Email =@Email,
DatumZaposlenja = @DatumZaposlenja,
Lozinka=@Lozinka, 
TipDjelatnikaID=@TipDjelatnikaID,
TimID =@TimID
where IDDjelatnik=@IDDjelatnik
end
go


create proc UpdateProjekt
@IDProjekt int,
@Naziv nvarchar(50),
@DatumOtvaranja date,
@KlijentID  int,
@VoditeljProjektaID int
as
begin
update Projekt
   SET Naziv = @Naziv,
DatumOtvaranja = @DatumOtvaranja,
KlijentID =@KlijentID,
VoditeljProjektaID = @VoditeljProjektaID
where IDProjekt=@IDProjekt
end
go

create proc GetDjelatnikID
@Ime nvarchar(50),
@Prezime nvarchar(50),
@Email nvarchar(50),
@DatumZaposlenja date,
@Lozinka nvarchar(50),
@TipDjelatnikaID int,
@TimID int
as
begin
select * from Djelatnik
where Ime=@Ime and Prezime=@Prezime and Lozinka=@Lozinka and TimID=@TimID and DatumZaposlenja= @DatumZaposlenja and Email=@Email and TipDjelatnikaID=@TipDjelatnikaID
end
go

create proc GetSviTipoviDjelatnika
as
begin
select * from TipDjelatnika
order by Naziv asc
end
go

create proc GetSviAktivniTimovi
as
begin
select * from Tim
where Aktivan='Aktivan'
order by Naziv asc
end
go

create proc InsertDjelatnik
@Ime nvarchar(50),
@Prezime nvarchar (50),
@Email  nvarchar (50),
@DatumZaposlenja date,
@Lozinka nvarchar(50),
@TipDjelatnikaID int,
@TimID int
as
begin
Insert Djelatnik (Ime, Prezime, Email, DatumZaposlenja, Lozinka, TipDjelatnikaID, TimID, Aktivan, Jezik)
  values (@Ime,
 @Prezime,
@Email,
@DatumZaposlenja,
@Lozinka, 
@TipDjelatnikaID,
@TimID, 'Aktivan','Hrvatski')
end
go

create proc UpdateAktivnostDjelatnika
@IDDjelatnik int,
@Aktivan nvarchar(50)
as
begin
update Djelatnik
set Aktivan= @Aktivan
where IDDjelatnik=@IDDjelatnik
end
go

create proc UpdateAktivnostTima
@IDTim int,
@Aktivan nvarchar(50)
as
begin
update Tim
set Aktivan= @Aktivan
where IDTim=@IDTim
end
go



create proc  GetVoditeljProjekta
@IDProjekt int
as
begin 
select * from Projekt as p
inner join ProjektDjelatnik as pd
on p.IDProjekt= pd.ProjektID
inner join  Djelatnik as d
on pd.DjelatnikID = d.IDDjelatnik
where ProjektID=@IDProjekt and DjelatnikID=VoditeljProjektaID
end
go

create proc GetKlijentProjekta
@IDProjekt int
as
begin 
select k.Naziv, k.IDKlijent, k.Aktivan  from Projekt as p
inner join Klijent as k
on p.KlijentID= k.IDKlijent
where IDProjekt=@IDProjekt
end
go

create proc GetDjelatniciNaProjektu
@IDProjekt int
as
begin 
select * from Projekt as p
inner join ProjektDjelatnik as pd
on p.IDProjekt= pd.ProjektID
inner join  Djelatnik as d
on pd.DjelatnikID = d.IDDjelatnik
where ProjektID=@IDProjekt 
end
go


create proc GetProjekt
@IDProjekt int
as
begin 
select * from Projekt as p
where IDProjekt=@IDProjekt 
end
go

create proc GetVoditeljProjektaId
@IDProjekt int
as
begin 
select * from Projekt as p
where IDProjekt=@IDProjekt 
end
go

create proc GetKlijentProjektaId
@IDProjekt int
as
begin 
select * from Projekt as p
where IDProjekt=@IDProjekt 
end
go


create proc GetDjelatniciNaProjektuVoditeljiTima
@IDProjekt int
as
begin 
select * from Projekt as p
inner join ProjektDjelatnik as pd
on p.IDProjekt= pd.ProjektID
inner join  Djelatnik as d
on pd.DjelatnikID = d.IDDjelatnik
where ProjektID=@IDProjekt and d.TipDjelatnikaID=2
end
go


create proc GetAktivniKlijenti
as
begin
select * from Klijent
where Aktivan = 'Aktivan'
order by Naziv asc
end
go

create proc GetSviKlijenti
as
begin
select * from Klijent
order by Naziv asc
end
go




create proc GetVoditeljiTima
as
begin
select * from Djelatnik
where TipDjelatnikaID=2
order by Ime,Prezime asc
end
go





create proc GetProjektId
@Naziv nvarchar(50),
@KlijentID int,
@DatumOtvaranja date,
@VoditeljProjektaID int
as
begin
select * from Projekt
where Naziv=@Naziv and KlijentID= @KlijentID and DatumOtvaranja=@DatumOtvaranja and VoditeljProjektaID=@VoditeljProjektaID
end
go



create proc InsertProjekt
@Naziv nvarchar(50),
@KlijentID int,
@DatumOtvaranja date,
@VoditeljProjektaID int
as
begin
insert Projekt(Naziv,KlijentID,DatumOtvaranja,VoditeljProjektaID,Aktivan)
values  (@Naziv , @KlijentID,@DatumOtvaranja,@VoditeljProjektaID,'Aktivan')
end
go


create proc UpdateAktivnostProjekta
@IDProjekt int,
@Aktivan nvarchar(50)
as
begin
update Projekt
set Aktivan= @Aktivan
where IDProjekt=@IDProjekt
end
go


create proc GetSviProjekti
as
begin
select * from Projekt
order by Naziv asc
end
go

create proc GetAktivnostProjekta
@IDProjekt int
as
begin
select * from Projekt
where IDProjekt=@IDProjekt
end
go




create proc GetKlijent
@IDKlijent int
as
begin
select * from Klijent
where IDKlijent=@IDKlijent
order by Naziv asc
end
go



create proc GetProjektiKlijenta
@IDKlijent int
as
begin
select * from Projekt
where KlijentID=@IDKlijent
order by Naziv asc
end
go


create proc UpdateProjektKlijentId
@IDKlijent int,
@IDProjekt int
as
begin
update Projekt
set KlijentID= @IDKlijent
where IDProjekt=@IDProjekt
end
go


create proc UpdateKlijent
@IDKlijent int,
@Naziv nvarchar(50)
as
begin
update Klijent
set Naziv= @Naziv
where IDKlijent=@IDKlijent
end
go






create proc InsertKlijent
@Naziv nvarchar(50)
as
begin
insert Klijent(Naziv,Aktivan)
values  (@Naziv,'Aktivan')
end
go

create proc GetKlijentId
@Naziv nvarchar(50)
as
begin
select * from Klijent
where Naziv=@Naziv 
end
go

create proc GetAktivnostKlijenta
@IDKlijent int
as
begin
select * from Klijent
where IDKlijent=@IDKlijent
end
go


create proc UpdateAktivnostKlijenta
@IDKlijent int,
@Aktivan nvarchar(50)
as
begin
update Klijent
set Aktivan= @Aktivan
where IDKlijent=@IDKlijent
end
go


create proc GetPrijavaRezultat
@Email nvarchar(50),
@Lozinka nvarchar(50)
as
begin
select count(*) as Rezultat from Djelatnik
where Email=@Email and Lozinka=@Lozinka and (TipDjelatnikaID =2 or TipDjelatnikaID=1)
end
go





create proc GetPrijavaDjelatnik
@Email nvarchar(50),
@Lozinka nvarchar(50)
as
begin
select * from Djelatnik
where Email=@Email and Lozinka=@Lozinka
end
go


create proc UpdateDjelatnikJezik
@IDDjelatnik int,
@Jezik nvarchar(50)
as
begin
update Djelatnik
set Jezik= @Jezik
where IDDjelatnik=@IDDjelatnik
end
go


create proc GetNazivProjektiTima
@IDTim int
as
begin
select distinct p.Naziv, p.IDProjekt from Projekt as p
inner join ProjektDjelatnik as pd
on p.IDProjekt = pd.ProjektID
inner join Djelatnik as d
on d.IDDjelatnik = pd.DjelatnikID
inner join Tim as t
on t.IDTim = d.TimID
where t.IDTim = @IDTim
end
go


create proc GetProjektiTima
@IDTim int
as
begin
select distinct * from Projekt as p
inner join ProjektDjelatnik as pd
on p.IDProjekt = pd.ProjektID
inner join Djelatnik as d
on d.IDDjelatnik = pd.DjelatnikID
inner join Tim as t
on t.IDTim = d.TimID
where t.IDTim = @IDTim
end
go

create proc GetPrekovremeniSatiTimaNaProjektu
@IDProjekt int,
@IDTim int,
@DatumSatnice date
as
begin
select cast(dateadd(millisecond,sum(datediff
(millisecond,0,cast(s.BrojPrekovremenihSati as datetime))),0) as time)  as BrojPrekovremenihSati from Satnica as s
inner join Projekt as p
on s.ProjektID = p.IDProjekt
inner join ProjektDjelatnik as pd
on p.IDProjekt = pd.ProjektID
inner join Djelatnik as d
on d.IDDjelatnik = pd.DjelatnikID
inner join Tim as t
on t.IDTim = d.TimID
where t.IDTim = @IDTim and p.IDProjekt = @IDProjekt and s.DatumSatnice = @DatumSatnice
end
go

create proc GetRedovniSatiTimaNaProjektu
@IDProjekt int,
@IDTim int,
@DatumSatnice date
as
begin
select cast(dateadd(millisecond,sum(datediff
(millisecond,0,cast(s.BrojRedovnihSati as datetime))),0) as time)  as BrojRedovnihSati from Satnica as s
inner join Projekt as p
on s.ProjektID = p.IDProjekt
inner join ProjektDjelatnik as pd
on p.IDProjekt = pd.ProjektID
inner join Djelatnik as d
on d.IDDjelatnik = pd.DjelatnikID
inner join Tim as t
on t.IDTim = d.TimID
where t.IDTim = @IDTim and p.IDProjekt = @IDProjekt and s.DatumSatnice = @DatumSatnice
end
go


create proc GetSatiNaProjektuKlijenta
@IDProjekt int,
@IDKlijent int,
@DatumSatnice date
as
begin
select cast(dateadd(millisecond,sum(datediff
(millisecond,0,cast(s.BrojRedovnihSati as datetime))),0) as time)  as BrojSati from Satnica as s
inner join Projekt as p
on s.ProjektID = p.IDProjekt
inner join Klijent as k
on k.IDKlijent = p.KlijentID
where k.IDKlijent = @IDKlijent and p.IDProjekt = @IDProjekt and s.DatumSatnice = @DatumSatnice
end
go


create proc GetNazivProjektiKlijenta
@IDKlijent int
as
begin
select distinct p.Naziv, p.IDProjekt from Projekt as p
inner join Klijent as k
on k.IDKlijent = p.KlijentID
where k.IDKlijent = @IDKlijent
end
go