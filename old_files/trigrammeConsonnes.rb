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
