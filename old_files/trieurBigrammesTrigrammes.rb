# Create an empty array.
lines = []
# Use foreach iterator to loop over lines in the file.
# ... Add chomped lines.
IO.foreach("test2.txt") do |line|
    lines.push(line.chomp())
end

$stdout.reopen("trigrammeConsonnes.txt", "w")

# Display elements in string array.
lines.each do |v|
  if (v =~ /[b-df-hj-np-tv-xzç]{3}/)
    puts v
  end
end

$stdout.reopen("trigrammeVoyelles.txt", "w")

# Display elements in string array.
lines.each do |v|
  if (v =~ /[aeiouyàâèéêëîïôöùûü]{3}/)
    puts v
  end
end

$stdout.reopen("bigrammeConsonnes.txt", "w")

# Display elements in string array.
lines.each do |v|
  if (v =~ /^[b-df-hj-np-tv-xzç]{2}$/)
    puts v
  end
end

$stdout.reopen("bigrammeVoyelles.txt", "w")

# Display elements in string array.
lines.each do |v|
  if (v =~ /^[aeiouyàâèéêëîïôöùûü]{2}$/)
    puts v
  end
end
