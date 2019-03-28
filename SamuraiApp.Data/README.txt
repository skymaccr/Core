
en el package manager console aparece la ayuda y se puede ejecutar todo
get-help entityframework

crear la migracion inicial
add-migration initial

crea un script SQL para ejecutarlo en la base de datos
script-migration

crea la base de datos descubriendo todo
update-database -verbose

agrega nuevos cambios a la migracion. el relationships es el nombre de la migracion
 add-migration relationships
 
 Crea todo el modelo a partir de la base de datos
 scaffold-dbcontext
 
 scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -Connection "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OdeToFood;Integrated Security = True;"
 
 
 