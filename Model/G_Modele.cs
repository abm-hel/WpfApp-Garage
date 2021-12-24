#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using Projet_Garage.Model;
using Projet_Garage.Acces;
#endregion

namespace Projet_Garage.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_Modele : G_Base
 {
  #region Constructeurs
  public G_Modele()
   : base()
  { }
  public G_Modele(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string modele, string motorisation, string carburant, int? cylindree, int? puissance, double? consommation, int? poids)
  { return new A_Modele(ChaineConnexion).Ajouter(modele, motorisation, carburant, cylindree, puissance, consommation, poids); }
  public int Modifier(int id, string modele, string motorisation, string carburant, int? cylindree, int? puissance, double? consommation, int? poids)
  { return new A_Modele(ChaineConnexion).Modifier(id, modele, motorisation, carburant, cylindree, puissance, consommation, poids); }
  public List<C_Modele> Lire(string Index)
  { return new A_Modele(ChaineConnexion).Lire(Index); }
  public C_Modele Lire_ID(int id)
  { return new A_Modele(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_Modele(ChaineConnexion).Supprimer(id); }
 }
}
