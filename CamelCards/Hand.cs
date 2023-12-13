namespace AOC2023.CamelCards;

public class HandJ : Hand
{
    public HandJ(IEnumerable<char> cards, int bid) : base(cards, bid, true)
    {
    }

    public override Type GetHandType()
    {
        var distinctCards = Cards.Where(x => x != Card.Joker).GroupBy(x => x).OrderByDescending(x => x.Count()).ToList();
        var jokerCount = Cards.Count(x => x == Card.Joker);
        var firstSetCount = (distinctCards.FirstOrDefault()?.Count() ?? 0)  + jokerCount;
        if(distinctCards.Count == 1 || jokerCount == 5)
            return Type.FiveOfAKind;
        if (firstSetCount == 4)
            return Type.FourOfAKind;
        if (firstSetCount == 3)
        {
            if (distinctCards.Count == 2)
                return Type.FullHouse;
            return Type.ThreeOfAKind;
        }
        if (distinctCards.Count == 3)
            return Type.TwoPair;
        if (distinctCards.Count == 4)
            return Type.OnePair;
        return Type.HighCard;
    }
    
}

public class Hand : IComparable 
{
    public List<Card> Cards { get; init; }
    public int Bid { get; init; }
    

    public Hand(IEnumerable<char> cards, int bid, bool jokers = false)
    {
        Cards = new List<Card>();
        Bid = bid;
        foreach (var cardType in cards)
        {
            Cards.Add(Card.GetCardType(cardType, jokers));
        }
    }
    
    public virtual Type GetHandType()
    {
        var distinctCards = Cards.GroupBy(x => x).OrderByDescending(x => x.Count()).ToList();
        if(distinctCards.Count == 1)
            return Type.FiveOfAKind;
        if (distinctCards[0].Count() == 4)
            return Type.FourOfAKind;
        if (distinctCards[0].Count() == 3)
        {
            if (distinctCards.Count == 2)
                return Type.FullHouse;
            return Type.ThreeOfAKind;
        }
        if (distinctCards.Count == 3)
            return Type.TwoPair;
        if (distinctCards.Count == 4)
            return Type.OnePair;
        return Type.HighCard;
    }
    
    public enum Type
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind,
    }

    public override bool Equals(object? obj)
    {
        if (obj is Hand hand)
            return Cards.SequenceEqual(hand.Cards);
        return base.Equals(obj);
    }

    protected bool Equals(Hand other)
    {
        return Cards.SequenceEqual(other.Cards);
    }

    public override int GetHashCode()
    {
        return Cards.GetHashCode();
    }

    public int CompareTo(object? obj)
    {
        if (obj is Hand hand)
        {
            if (this > hand)
                return 1;
            if (this < hand)
                return -1;
            return 0;
        }

        return 0;
    }

    public static bool operator >(Hand a, Hand b)
    {
        //  First check other type
        var aType = a.GetHandType();
        var bType = b.GetHandType();
        if (aType != bType)
            return a.GetHandType() > b.GetHandType();
        else
        {
            for (int i = 0; i < 5; i++)
            {
                var aCard = a.Cards[i];
                var bCard = b.Cards[i];
                if (aCard != bCard)
                    return aCard > bCard;
            }
        }
        return false;
    }

    public static bool operator <(Hand a, Hand b)
    {
        //  First check other type
        var aType = a.GetHandType();
        var bType = b.GetHandType();
        if (aType != bType)
            return a.GetHandType() < b.GetHandType();
        else
        {
            for (int i = 0; i < 5; i++)
            {
                var aCard = a.Cards[i];
                var bCard = b.Cards[i];
                if (aCard != bCard)
                    return aCard < bCard;
            }
        }
        return false;
    }
}

public class Card : IComparable
{
    private static readonly Card A = new Card('A', 13);
    private static readonly Card K = new Card('K', 12);
    private static readonly Card Q = new Card('Q', 11);
    private static readonly Card J = new Card('J', 10);
    private static readonly Card T = new Card('T', 9);
    private static readonly Card Nine = new Card('9', 8);
    private static readonly Card Eight = new Card('8', 7);
    private static readonly Card Seven = new Card('7', 6);
    private static readonly Card Six = new Card('6', 5);
    private static readonly Card Five = new Card('5', 4);
    private static readonly Card Four = new Card('4', 3);
    private static readonly Card Three = new Card('3', 2);
    private static readonly Card Two = new Card('2', 1);
    public static readonly Card Joker = new Card('J', 0);
    
    public char CardType;

    public int Value { get; }
    
    private Card(char c, int value)
    {
        CardType = c;
        Value = value;
    }

    public static Card GetCardType(char c, bool jokers = false)
    {
        return c switch
        {
            'A' => A,
            'K' => K,
            'Q' => Q,
            'J' => jokers? Joker : J,
            'T' => T,
            '9' => Nine,
            '8' => Eight,
            '7' => Seven,
            '6' => Six,
            '5' => Five,
            '4' => Four,
            '3' => Three,
            '2' => Two,
            _ => throw new ArgumentOutOfRangeException(nameof(c), "Invalid card type")
        };
    }

    public static bool operator >(Card a, Card b)
    {
        return a.Value > b.Value;
    }

    public static bool operator <(Card a, Card b)
    {
        return a.Value < b.Value;
    }


    public int CompareTo(object? obj)
    {
        if (obj is Card card)
        {
            if (this.Value > card.Value)
                return 1;
            if (this.Value < card.Value)
                return -1;
            return 0;
        }
        return -1;
    }
}