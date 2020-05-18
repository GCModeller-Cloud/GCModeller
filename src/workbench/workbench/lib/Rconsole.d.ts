/// <reference path="../../typescript/build/linq.d.ts" />
/// <reference path="../vendor/console/simple-console.d.ts" />
declare namespace shell {
    function handle_command(command: string): void;
}
interface Message extends IMsg<string> {
    content_type: string;
    err: any;
    server_time: number;
    warnings: any[];
}
declare let con: System.Console;
