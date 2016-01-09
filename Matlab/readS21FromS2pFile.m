function [ freq, amp, phs ] = readS21FromS2pFile( file_path, s_param )
% Assume that the file is containing only one frequency.
% Also assume that the first 13 lines are not relevant

if nargin==0
    file_path = 'C:\\FieldFox\\201510041618086540_mosh_4700\\1618086630_0.s2p';
    s_param = 'S21';
end

fid = fopen(file_path);

tline = fgetl(fid);
line_ind = 0;
while ischar(tline)
    line_ind = line_ind + 1;
    if line_ind > 13        
        arr = sscanf(tline,'%f');
        %disp([arr(1), arr(4), arr(5)]);
        switch s_param
            case 'S21'
                amp(line_ind-13) = arr(4);
                phs(line_ind-13) = arr(5);
            case 'S11'
                amp(line_ind-13) = arr(2);
                phs(line_ind-13) = arr(3);
        end
        
        freq = arr(1);
    end
    tline = fgetl(fid);
end

fclose(fid);

end

