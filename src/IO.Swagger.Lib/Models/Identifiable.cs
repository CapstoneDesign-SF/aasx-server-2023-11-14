/*
 * DotAAS Part 2 | HTTP/REST | Asset Administration Shell Repository
 *
 * An exemplary interface combination for the use case of an Asset Administration Shell Repository
 *
 * OpenAPI spec version: Final-Draft
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Identifiable : Referable, IEquatable<Identifiable>
    {
        /// <summary>
        /// Gets or Sets Administration
        /// </summary>

        [DataMember(Name = "administration")]
        public AdministrativeInformation Administration { get; set; }

        /// <summary>
        /// Gets or Sets Identification
        /// </summary>
        [Required]

        [DataMember(Name = "identification")]
        public string Identification { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Identifiable {\n");
            sb.Append("  Administration: ").Append(Administration).Append("\n");
            sb.Append("  Identification: ").Append(Identification).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Identifiable)obj);
        }

        /// <summary>
        /// Returns true if Identifiable instances are equal
        /// </summary>
        /// <param name="other">Instance of Identifiable to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Identifiable other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Administration == other.Administration ||
                    Administration != null &&
                    Administration.Equals(other.Administration)
                ) &&
                (
                    Identification == other.Identification ||
                    Identification != null &&
                    Identification.Equals(other.Identification)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Administration != null)
                    hashCode = hashCode * 59 + Administration.GetHashCode();
                if (Identification != null)
                    hashCode = hashCode * 59 + Identification.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Identifiable left, Identifiable right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identifiable left, Identifiable right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
