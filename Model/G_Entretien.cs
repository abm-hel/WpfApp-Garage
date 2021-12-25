#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using Projet_Garage.Classes;
using Projet_Garage.Acces;
#endregion

namespace Projet_Garage.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_Entretien : G_Base
 {
  #region Constructeurs
  public G_Entretien()
   : base()
  { }
  public G_Entretien(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? vehiculeId, DateTime? datePassage)
  { return new A_Entretien(ChaineConnexion).Ajouter(vehiculeId, datePassage); }
  public int Modifier(int id, int? vehiculeId, DateTime? datePassage)
  { return new A_Entretien(ChaineConnexion).Modifier(id, vehiculeId, datePassage); }
  public List<C_Entretien> Lire(string Index)
  { return new A_Entretien(ChaineConnexion).Lire(Index); }
  public C_Entretien Lire_ID(int id)
  { return new A_Entretien(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_Entretien(ChaineConnexion).Supprimer(id); }
 }
}
