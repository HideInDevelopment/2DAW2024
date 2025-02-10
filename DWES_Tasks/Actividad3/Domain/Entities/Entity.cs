namespace Actividad3.Domain.Entities;

public class Entity<TKey>
{
    public TKey Id { get; set; }

    public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right) => 
        ReferenceEquals(left, right) || left is not null && left.Equals(right);
    
    public static bool operator !=(Entity<TKey> left, Entity<TKey> right) => !(left == right);
    
}