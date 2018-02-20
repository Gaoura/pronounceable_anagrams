# Create an empty array.
lines = []
# Use foreach iterator to loop over lines in the file.
# ... Add chomped lines.
IO.foreach("test2.txt") do |line|
    lines.push(line.chomp())
end

$stdout.reopen("trigrammeVoyelles.txt", "w")

# Display elements in string array.
lines.each do |v|
  if (v =~ /[aeiouyàâèéêëîïôöùûü]{3}/)
    puts v
  end
end
