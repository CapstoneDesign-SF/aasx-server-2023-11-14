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
    public partial class RelationshipElement : SubmodelElement, IEquatable<RelationshipElement>
    {
        /// <summary>
        /// Gets or Sets First
        /// </summary>
        [Required]

        [DataMember(Name = "first")]
        public Reference First { get; set; }

        /// <summary>
        /// Gets or Sets Second
        /// </summary>
        [Required]

        [DataMember(Name = "second")]
        public Reference Second { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RelationshipElement {\n");
            sb.Append("  First: ").Append(First).Append("\n");
            sb.Append("  Second: ").Append(Second).Append("\n");
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
            return obj.GetType() == GetType() && Equals((RelationshipElement)obj);
        }

        /// <summary>
        /// Returns true if RelationshipElement instances are equal
        /// </summary>
        /// <param name="other">Instance of RelationshipElement to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RelationshipElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    First == other.First ||
                    First != null &&
                    First.Equals(other.First)
                ) &&
                (
                    Second == other.Second ||
                    Second != null &&
                    Second.Equals(other.Second)
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
                if (First != null)
                    hashCode = hashCode * 59 + First.GetHashCode();
                if (Second != null)
                    hashCode = hashCode * 59 + Second.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(RelationshipElement left, RelationshipElement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RelationshipElement left, RelationshipElement right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
