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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PermissionsPerObject : IEquatable<PermissionsPerObject>
    {
        /// <summary>
        /// Gets or Sets _Object
        /// </summary>

        [DataMember(Name = "object")]
        //TODO:
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasReference _Object { get; set; }
        public Reference _Object { get; set; }

        /// <summary>
        /// Gets or Sets Permission
        /// </summary>

        [DataMember(Name = "permission")]
        public List<Permission> Permission { get; set; }

        /// <summary>
        /// Gets or Sets TargetObjectAttributes
        /// </summary>

        [DataMember(Name = "targetObjectAttributes")]
        //TODO:
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasObjectAttributes TargetObjectAttributes { get; set; }
        public ObjectAttributes TargetObjectAttributes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PermissionsPerObject {\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  Permission: ").Append(Permission).Append("\n");
            sb.Append("  TargetObjectAttributes: ").Append(TargetObjectAttributes).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return obj.GetType() == GetType() && Equals((PermissionsPerObject)obj);
        }

        /// <summary>
        /// Returns true if PermissionsPerObject instances are equal
        /// </summary>
        /// <param name="other">Instance of PermissionsPerObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PermissionsPerObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    _Object == other._Object ||
                    _Object != null &&
                    _Object.Equals(other._Object)
                ) &&
                (
                    Permission == other.Permission ||
                    Permission != null &&
                    Permission.SequenceEqual(other.Permission)
                ) &&
                (
                    TargetObjectAttributes == other.TargetObjectAttributes ||
                    TargetObjectAttributes != null &&
                    TargetObjectAttributes.Equals(other.TargetObjectAttributes)
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
                if (_Object != null)
                    hashCode = hashCode * 59 + _Object.GetHashCode();
                if (Permission != null)
                    hashCode = hashCode * 59 + Permission.GetHashCode();
                if (TargetObjectAttributes != null)
                    hashCode = hashCode * 59 + TargetObjectAttributes.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PermissionsPerObject left, PermissionsPerObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PermissionsPerObject left, PermissionsPerObject right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
