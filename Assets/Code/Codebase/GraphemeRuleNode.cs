using System.Collections.Generic;
using UnityEngine.Assertions;

public sealed partial class GraphemeRuleSet
{
    private sealed partial class GraphemeRuleNode
    {
        public Letter Letter { get; private set; }
        public Dictionary<Letter, GraphemeRuleNode> ønext_rule_nodes { get; private set; }

        public GraphemeRuleNode(Word rule)
        {
            ønext_rule_nodes = new Dictionary<Letter, GraphemeRuleNode>();
            Letter = rule[0];
            AddRule(rule.Slice(1));
        }

        public bool AddRule(Word rule)
        {
            if (rule.IsEmpty)
            {
                return false;
            }

            Letter letter = rule[0];
            if (ønext_rule_nodes.ContainsKey(letter))
            {
                bool rule_added = ønext_rule_nodes[letter].AddRule(rule.Slice(1));
                return rule_added;
            }

            GraphemeRuleNode next_grapheme_set = new GraphemeRuleNode(rule);
            ønext_rule_nodes.Add(letter, next_grapheme_set);
            return true;
        }

        public bool RespectRules(Word grapheme_to_be_tested)
        {
            /*if (grapheme_to_be_tested.IsEmpty)
            {
                return true;
            }

            Letter letter = grapheme_to_be_tested[0];

            if (letter != Letter)
            {
                return false;
            }

            Word temp_grapheme_to_be_tested = grapheme_to_be_tested.Slice(1);

            if (temp_grapheme_to_be_tested.IsEmpty)
            {
                return true;
            }

            letter = temp_grapheme_to_be_tested[0];

            if (!ønext_rule_nodes.ContainsKey(letter))
            {
                return false;
            }
            */
            Letter letter = grapheme_to_be_tested[0];
            if (!ønext_rule_nodes.ContainsKey(letter))
            {
                return false;
            }

            bool grapheme_respects_rules = ønext_rule_nodes[letter].RespectRules(grapheme_to_be_tested);
            return grapheme_respects_rules;
        }
    }
}