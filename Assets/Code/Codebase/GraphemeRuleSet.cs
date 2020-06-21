using System.Collections.Generic;
using UnityEngine.Assertions;

public sealed partial class GraphemeRuleSet
{
    private Dictionary<Letter, GraphemeRuleNode> ørules;

    public GraphemeRuleSet()
    {
        ørules = new Dictionary<Letter, GraphemeRuleNode>();
    }

    public bool AddRule(Word rule)
    {
        if (rule.IsEmpty)
        {
            return false;
        }

        Letter letter = rule[0];
        if (!ørules.ContainsKey(letter))
        {
            GraphemeRuleNode node = new GraphemeRuleNode(rule);
            ørules.Add(letter, node);
            return true;
        }

        bool rule_added = ørules[letter].AddRule(rule.Slice(1));
        return rule_added;
    }


    public bool RespectsRules(Word word_to_be_tested)
    {
        Word copy_to_progress_in_the_word = word_to_be_tested.Slice(0);

        while (!copy_to_progress_in_the_word.IsEmpty)
        {
            Word copy_to_progress_in_the_rules = copy_to_progress_in_the_word.Slice(0);

            Letter letter = copy_to_progress_in_the_rules[0];

            if (!ørules.ContainsKey(letter))
            {
                return false;
            }

            GraphemeRuleNode node = ørules[letter];
            int grapheme_length = 1;
            bool more_rules_available = true;

            while (more_rules_available)
            {
                copy_to_progress_in_the_rules = copy_to_progress_in_the_rules.Slice(1);

                if (copy_to_progress_in_the_rules.IsEmpty)
                {
                    return true;
                }

                letter = copy_to_progress_in_the_rules[0];

                if (node.ønext_rule_nodes.ContainsKey(letter))
                {
                    node = node.ønext_rule_nodes[letter];
                    ++grapheme_length;
                }
                else
                {
                    more_rules_available = false;
                }
            }

            if (grapheme_length < 3)
            {
                return false;
            }

            copy_to_progress_in_the_word = copy_to_progress_in_the_word.Slice(1);
        }

        return true;
    }


    private sealed partial class GraphemeRuleNode
    {

    }
}
