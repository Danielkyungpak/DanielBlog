using DanielBlog.Web.Models.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Models.Poker
{
    public class CardLogic
    {
        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        public enum Value
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
        public class Card
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public Suit Suit { get; set; }

            [JsonConverter(typeof(StringEnumConverter))]
            public Value Value { get; set; }
            public bool Change { get; set; }

        }

        public class Hand
        {
            public IEnumerable<Card> Cards { get; set; }

            public bool Contains(Value val)
            {
                return Cards.Where(c => c.Value == val).Any();
            }

            private bool IsPair
            {
                get
                {
                    return Cards.GroupBy(h => h.Value)
                               .Where(g => g.Count() == 2)
                               .Count() == 1;
                }
            }

            public bool IsJacksOrBetter
            {
                get
                {
                    if (Contains(Value.Ace) ||
                        Contains(Value.King) ||
                        Contains(Value.Queen) ||
                        Contains(Value.Jack))
                    {
                        if (Cards.GroupBy(h => h.Value == Value.Ace)
                            .Where(g => g.Count() == 2)
                            .Count() == 1)
                        {
                            return true;
                        }
                        else if (Cards.GroupBy(h => h.Value == Value.King)
                            .Where(g => g.Count() == 2)
                            .Count() == 1)
                        {
                            return true;
                        }
                        else if (Cards.GroupBy(h => h.Value == Value.Queen)
                           .Where(g => g.Count() == 2)
                           .Count() == 1)
                        {
                            return true;
                        }
                        else if (Cards.GroupBy(h => h.Value == Value.Jack)
                           .Where(g => g.Count() == 2)
                           .Count() == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }


            public bool IsTwoPair
            {
                get
                {
                    return Cards.GroupBy(h => h.Value)
                                .Where(g => g.Count() == 2)
                                .Count() == 2;
                }
            }

            public bool IsThreeOfAKind
            {
                get
                {
                    return Cards.GroupBy(h => h.Value)
                                .Where(g => g.Count() == 3)
                                .Any();
                }
            }

            public bool IsFourOfAKind
            {
                get
                {
                    return Cards.GroupBy(h => h.Value)
                                .Where(g => g.Count() == 4)
                                .Any();
                }
            }

            public bool IsFlush
            {
                get
                {
                    return Cards.GroupBy(h => h.Suit).Count() == 1;
                }
            }

            public bool IsFullHouse
            {
                get
                {
                    return IsPair && IsThreeOfAKind;
                }
            }

            public bool IsStraight
            {
                get
                {
                    // If there is an Ace, we have to handle the 10,J,Q,K,A case, which isn't handled by the code
                    // below because Ace is normally 0
                    if (Contains(Value.Ace) &&
                        Contains(Value.King) &&
                        Contains(Value.Queen) &&
                        Contains(Value.Jack) &&
                        Contains(Value.Ten))
                    {
                        return true;
                    }

                    var ordered = Cards.OrderBy(h => h.Value).ToArray();
                    var straightStart = (int)ordered.First().Value;
                    for (var i = 1; i < ordered.Length; i++)
                    {
                        if ((int)ordered[i].Value != straightStart + i)
                            return false;
                    }

                    return true;
                }

            }

            public bool IsStraightFlush
            {
                get
                {
                    return IsStraight && IsFlush;
                }
            }

            public bool IsRoyalStraightFlush
            {
                get
                {
                    return IsStraight && IsFlush && Contains(Value.Ace) && Contains(Value.King);
                }
            }
        }

        public class Deck
        {
            public Deck()
            {
                var cards = new List<Card>();
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Value value in Enum.GetValues(typeof(Value)))
                    {
                        cards.Add(new Card { Suit = suit, Value = value, Change = true });

                    }
                }
                _cards = cards;

            }

            List<Card> _cards;
            public List<Card> Cards { get { return _cards; } }

            public Hand DealStandardHand()
            {
                return new Hand { Cards = Cards.Take(5) };
            }

            public Hand DealNonHeldCards(Card[] payload)
            {
                Card[] returnedCards = new Card[5];
                for (int i = 0; i < payload.Length; i++)
                {
                    if (payload[i].Change == true)
                    {
                        int k = rng.Next(i + 1);
                        Card value = Cards[k];
                        Cards[k] = Cards[i];
                        Cards[i] = value;
                        returnedCards[i] = Cards[i];
                        Cards.RemoveAll(c => c.Value == Cards[i].Value && c.Suit == Cards[i].Suit);
                    }
                    else
                    {
                        returnedCards[i] = payload[i];
                    }

                }

                return new Hand { Cards = returnedCards };

            }

            private static Random rng = new Random();
            public void Shuffle(List<Card> cards)
            {
                int n = cards.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    Card value = cards[k];
                    cards[k] = Cards[n];
                    cards[n] = value;
                }
            }
            public List<Card> RemoveCards(Card[] payload)
            {
                for (int i = 0; i < payload.Length; i++)
                {
                    Cards.RemoveAll(c => c.Value == payload[i].Value && c.Suit == payload[i].Suit);

                }
                return Cards;
            }

        }
    }
}