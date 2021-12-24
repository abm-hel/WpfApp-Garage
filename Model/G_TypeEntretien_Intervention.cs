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
 public class G_TypeEntretien_Intervention : G_Base
 {
  #region Constructeurs
  public G_TypeEntretien_Intervention()
   : base()
  { }
  public G_TypeEntretien_Intervention(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? interventionId, int? entretienId, double? prixHeure, double? prix, double? tva)
  { return new A_TypeEntretien_Intervention(ChaineConnexion).Ajouter(interventionId, entretienId, prixHeure, prix, tva); }
  public int Modifier(int id, int? interventionId, int? entretienId, double? prixHeure, double? prix, double? tva)
  { return new A_TypeEntretien_Intervention(ChaineConnexion).Modifier(id, interventionId, entretienId, prixHeure, prix, tva); }
  public List<C_TypeEntretien_Intervention> Lire(string Index)
  { return new A_TypeEntretien_Intervention(ChaineConnexion).Lire(Index); }
  public C_TypeEntretien_Intervention Lire_ID(int id)
  { return new A_TypeEntretien_Intervention(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_TypeEntretien_Intervention(ChaineConnexion).Supprimer(id); }
 }
}
