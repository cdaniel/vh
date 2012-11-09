﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VH.Engine.World.Beings {

    public class SkillSet: IEnumerable {

        #region fields

        private string title;
        private List<Skill> skills = new List<Skill>();

        #endregion

        #region constructors

        public SkillSet(string title, params Skill[] skills) {
            this.title = title;
            foreach (Skill skill in skills) {
                this.skills.Add(skill);
            }
        }

        #endregion

        #region properties

        public Skill this[string key] {
            get {
                return (
                    from Skill skill in skills
                    where skill.Id == key
                    select skill
                ).Single();
            }
        }

        #endregion

        #region public methods

        public IEnumerator GetEnumerator() {
            foreach (Skill skill in skills) yield return skill;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder(title + ":\n");
            foreach (Skill skill in skills) {
                sb.Append(skill.ToString() + "\n");
            }
            return sb.ToString();
        }

        #endregion

    }
}
