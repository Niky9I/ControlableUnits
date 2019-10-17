﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 

using System.Xml.Schema;

namespace Utils.ResourceManager.Factory.Config {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class AttackDistance {
        
        private float minDistanceField;
        
        private float maxDistanceField;
        
        /// <remarks/>
        public float MinDistance {
            get {
                return this.minDistanceField;
            }
            set {
                this.minDistanceField = value;
            }
        }
        
        /// <remarks/>
        public float MaxDistance {
            get {
                return this.maxDistanceField;
            }
            set {
                this.maxDistanceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Attack {
        
        private float minAttackField;
        
        private float maxAttackField;
        
        private float attackSpeedField;
        
        private AttackDistance attackDistanceField;
        
        /// <remarks/>
        public float MinAttack {
            get {
                return this.minAttackField;
            }
            set {
                this.minAttackField = value;
            }
        }
        
        /// <remarks/>
        public float MaxAttack {
            get {
                return this.maxAttackField;
            }
            set {
                this.maxAttackField = value;
            }
        }
        
        /// <remarks/>
        public float AttackSpeed {
            get {
                return this.attackSpeedField;
            }
            set {
                this.attackSpeedField = value;
            }
        }
        
        /// <remarks/>
        public AttackDistance AttackDistance {
            get {
                return this.attackDistanceField;
            }
            set {
                this.attackDistanceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Build {
        
        private float buildTimeField;
        
        /// <remarks/>
        public float BuildTime {
            get {
                return this.buildTimeField;
            }
            set {
                this.buildTimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class UnitConfig : IUnitConfig
    {
        [XmlAttribute("noNamespaceSchemaLocation", Namespace = XmlSchema.InstanceNamespace)]
        public string namespaceAttribute = "UnitConfig.xsd";
        
        private float hpField;
        
        private Attack attackField;
        
        private float defenseField;
        
        private Build buildField;
        
        private float speedField;
        
        private float costField;
        
        private string prefabPathField;
        
        /// <remarks/>
        public float Hp {
            get {
                return this.hpField;
            }
            set {
                this.hpField = value;
            }
        }

        public float MinAttack => Attack.MinAttack;
        public float MaxAttack => Attack.MaxAttack;
        public float AttackSpeed => Attack.AttackSpeed;
        public float MinDistance => Attack.AttackDistance.MinDistance;
        public float MaxDistance => Attack.AttackDistance.MaxDistance;

        /// <remarks/>
        public Attack Attack {
            get {
                return this.attackField;
            }
            set {
                this.attackField = value;
            }
        }
        
        /// <remarks/>
        public float Defense {
            get {
                return this.defenseField;
            }
            set {
                this.defenseField = value;
            }
        }

        public float BuildTime { get; }

        /// <remarks/>
        public Build Build {
            get {
                return this.buildField;
            }
            set {
                this.buildField = value;
            }
        }
        
        /// <remarks/>
        public float Speed {
            get {
                return this.speedField;
            }
            set {
                this.speedField = value;
            }
        }
        
        /// <remarks/>
        public float Cost {
            get {
                return this.costField;
            }
            set {
                this.costField = value;
            }
        }
        
        /// <remarks/>
        public string PrefabPath {
            get {
                return this.prefabPathField;
            }
            set {
                this.prefabPathField = value;
            }
        }

        public override string ToString()
        {
            return $"HP: {Hp}, MinAttack: {MinAttack}, MaxAttack: {MaxAttack}, Defense: {Defense}, " +
                   $"BuildTime: {BuildTime}, MoveSpeed: {Speed}, AttackSpeed: {AttackSpeed}, " +
                   $"MinAttackDistance: {MinDistance}, MaxAttackDistance: {MaxDistance}, " +
                   $"PrefabPath: {PrefabPath}, Cost: {Cost}";
        }
    }
}