#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using Projet_Garage.Model;
using Projet_Garage.Acces;
#endregion

namespace Projet_Garage.Model
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_Vehicule : G_Base
 {
  #region Constructeurs
  public G_Vehicule()
   : base()
  { }
  public G_Vehicule(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? modeleId, int? clientId, string immatriculation, DateTime? datePremiereImmatriculation, string couleur, Int64? kilometrage)
  { return new A_Vehicule(ChaineConnexion).Ajouter(modeleId, clientId, immatriculation, datePremiereImmatriculation, couleur, kilometrage); }
  public int Modifier(int id, int? modeleId, int? clientId, string immatriculation, DateTime? datePremiereImmatriculation, string couleur, Int64? kilometrage)
  { return new A_Vehicule(ChaineConnexion).Modifier(id, modeleId, clientId, immatriculation, datePremiereImmatriculation, couleur, kilometrage); }
  public List<C_Vehicule> Lire(string Index)
  { return new A_Vehicule(ChaineConnexion).Lire(Index); }
  public C_Vehicule Lire_ID(int id)
  { return new A_Vehicule(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_Vehicule(ChaineConnexion).Supprimer(id); }
 }
}
