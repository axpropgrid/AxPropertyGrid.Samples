using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AxControls;

namespace AxPropertyGrid.Samples.Models
{
    /// <summary>
    /// Demonstrates AxGridSetting fluent API for configuring the property grid
    /// without using any attributes on the class.
    /// This example models a server connection configuration.
    /// </summary>
    public class ServerConnectionSettings
    {
        // --- Basic properties (no attributes needed) ---

        public string ServerName { get; set; } = "localhost";
        public int Port { get; set; } = 5432;
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "";
        public bool UseSsl { get; set; } = true;
        public bool AllowSelfSigned { get; set; } = false;
        public int ConnectionTimeout { get; set; } = 30;
        public int MaxRetryCount { get; set; } = 3;
        public int RetryInterval { get; set; } = 5;
        public double LatencyThreshold { get; set; } = 500.0;
        public float DataRate { get; set; } = 1.5f;
        public string ConnectionNotes { get; set; } = "Enter any notes about this connection here.";

        // --- Enum property ---
        public enum ProtocolType { Tcp, Udp, Http, WebSockets }
        public ProtocolType Protocol { get; set; } = ProtocolType.Tcp;
        public enum CompressionMode { None, GZip, Deflate, Lz4 }
        public CompressionMode Compression { get; set; } = CompressionMode.GZip;

        // --- DateTime properties ---
        public DateTime LastConnected { get; set; } = DateTime.Now;
        public DateTime CertificateExpiry { get; set; } = DateTime.Now.AddYears(1);

        // --- Nullable bool ---
        public bool? IsOnline { get; set; } = null;

        // --- Size and Point ---
        public Size WindowSize { get; set; } = new Size(800, 600);
        public Point WindowPosition { get; set; } = new Point(100, 100);

        // --- Other numeric types ---
        public long MaxBytesPerSecond { get; set; } = 1048576;
        public short Priority { get; set; } = 5;
        public byte ThreadCount { get; set; } = 4;

        public double Balance { get; set; } = 12345.8;

        // --- Property that should be hidden ---
        public string InternalToken { get; set; } = "";

        public static AxGridSetting BuildSettings()
        {
            var setting = new AxGridSetting(typeof(ServerConnectionSettings));

            // Hide internal property
            setting.AddIgnoredProperty(nameof(InternalToken));

            // --- Create groups with display text and ordering ---
            setting.CreateGroup("Connection", "Connection", groupOrder: 1);
            setting.CreateGroup("Security", "Security", groupOrder: 2);
            setting.CreateGroup("Performance", "Performance", groupOrder: 3);
            setting.CreateGroup("Layout", "Layout", groupOrder: 4);
            setting.CreateGroup("DateTime", "Date & Time", groupOrder: 5);

            setting.CreateGroup("Currency", "货币", groupOrder: 6);

            // === Connection group ===
            setting.SetPropertyGeneralInformation(nameof(ServerName), "Server Name", "The hostname or IP address of the server", "Connection");
            setting.SetPropertyGeneralInformation(nameof(Port), "Port", "Network port number (1-65535)", "Connection");
            setting.SetPropertyGeneralInformation(nameof(Protocol), "Protocol", "Network protocol to use", "Connection");
            setting.SetPropertyGeneralInformation(nameof(Username), "Username", "Authentication username", "Connection");
            setting.SetPropertyGeneralInformation(nameof(Password), "Password", "Authentication password", "Connection");
            setting.SetPropertyGeneralInformation(nameof(ConnectionNotes), "Notes", "Additional notes about this connection", "Connection");

            // Port: integer with range and step
            setting.SetNumericTypePropertyValueStepRange<int>(nameof(Port), 1, 1, 65535);

            // Protocol enum: use radio group
            setting.SetPropertyEditorStyle(nameof(Protocol), AxControls.Controls.ValueEditorStyle.Enum_RadioGroup_Horizontal);
            setting.SetEnumValueDisplayText(ProtocolType.Tcp, "TCP/IP");
            setting.SetEnumValueDisplayText(ProtocolType.Udp, "UDP");
            setting.SetEnumValueDisplayText(ProtocolType.Http, "HTTP");
            setting.SetEnumValueDisplayText(ProtocolType.WebSockets, "WebSockets");

            // Compression enum: use vertical radio group
            setting.SetPropertyGeneralInformation(nameof(Compression), "Compression", "Data compression algorithm", "Performance");
            setting.SetPropertyEditorStyle(nameof(Compression), AxControls.Controls.ValueEditorStyle.Enum_RadioGroup_Vertical);
            setting.SetEnumValueDisplayText(CompressionMode.None, "Disabled");
            setting.SetEnumValueDisplayText(CompressionMode.GZip, "GZip");
            setting.SetEnumValueDisplayText(CompressionMode.Deflate, "Deflate");
            setting.SetEnumValueDisplayText(CompressionMode.Lz4, "LZ4");

            // Notes: multiline string
            setting.SetStringPropertyAcceptReturn(nameof(ConnectionNotes), true);

            // Password: multiline (to test String_TextBox_Wrap_MultiLine via GridSetting)
            setting.SetPropertyEditorStyle(nameof(Password), AxControls.Controls.ValueEditorStyle.String_TextBox_Wrap_MultiLine);

            // === Security group ===
            setting.SetPropertyGeneralInformation(nameof(UseSsl), "Enable SSL", "Use encrypted connection", "Security");
            setting.SetPropertyGeneralInformation(nameof(AllowSelfSigned), "Allow Self-Signed", "Accept self-signed certificates", "Security");
            setting.SetPropertyGeneralInformation(nameof(CertificateExpiry), "Certificate Expiry", "SSL certificate expiration date", "Security");
            setting.SetPropertyGeneralInformation(nameof(IsOnline), "Online Status", "Current connection status (null = unknown)", "Security");

            // SSL toggle switch
            setting.SetPropertyEditorStyle(nameof(UseSsl), AxControls.Controls.ValueEditorStyle.Bool_ToggleSwitch);
            setting.SetPropertyEditorStyle(nameof(AllowSelfSigned), AxControls.Controls.ValueEditorStyle.Bool_ToggleSwitch);

            // === Performance group ===
            setting.SetPropertyGeneralInformation(nameof(ConnectionTimeout), "Timeout (sec)", "Connection timeout in seconds", "Performance");
            setting.SetPropertyGeneralInformation(nameof(MaxRetryCount), "Max Retries", "Maximum number of retry attempts", "Performance");
            setting.SetPropertyGeneralInformation(nameof(RetryInterval), "Retry Interval", "Seconds between retry attempts", "Performance");
            setting.SetPropertyGeneralInformation(nameof(LatencyThreshold), "Latency Threshold", "Maximum acceptable latency in ms", "Performance");
            setting.SetPropertyGeneralInformation(nameof(DataRate), "Data Rate", "Data transfer rate in MB/s", "Performance");
            setting.SetPropertyGeneralInformation(nameof(MaxBytesPerSecond), "Max Bytes/Sec", "Maximum bytes per second limit", "Performance");
            setting.SetPropertyGeneralInformation(nameof(Priority), "Priority", "Connection priority (0-10)", "Performance");
            setting.SetPropertyGeneralInformation(nameof(ThreadCount), "Thread Count", "Number of worker threads", "Performance");

            // Numeric ranges and formatting
            setting.SetNumericTypePropertyValueStepRange<int>(nameof(ConnectionTimeout), 5, 5, 300);
            setting.SetNumericTypePropertyValueStepRange<int>(nameof(MaxRetryCount), 1, 0, 10);
            setting.SetNumericTypePropertyValueStepRange<int>(nameof(RetryInterval), 1, 1, 60);
            setting.SetNumericTypePropertySuffix(nameof(RetryInterval), "sec");
            setting.SetNumericTypePropertySuffix(nameof(ConnectionTimeout), "sec");

            setting.SetNumericTypePropertyValueStepRange<double>(nameof(LatencyThreshold), 50, 0, 10000);
            setting.SetNumericTypePropertySuffix(nameof(LatencyThreshold), "ms");

            setting.SetNumericTypePropertyValueStepRange<float>(nameof(DataRate), 0.1f, 0.0f, 100.0f);
            setting.SetNumericTypePropertySuffix(nameof(DataRate), "MB/s");

            setting.SetNumericTypePropertyValueStepRange<long>(nameof(MaxBytesPerSecond), 1024, 0, long.MaxValue);
            setting.SetNumericTypePropertyPrefix(nameof(MaxBytesPerSecond), "R");

            setting.SetNumericTypePropertyValueStepRange<short>(nameof(Priority), 1, 0, 10);

            setting.SetNumericTypePropertyValueStepRange<byte>(nameof(ThreadCount), 1, 1, 32);

            // Line up Timeout and Retries on the same row
            setting.SetPropertyInUniformWidthLine(nameof(ConnectionTimeout), "PerfLine1", 0);
            setting.SetPropertyInUniformWidthLine(nameof(MaxRetryCount), "PerfLine1", 1);
            setting.SetPropertyInUniformWidthLine(nameof(RetryInterval), "PerfLine1", 2);

            // Place MaxBytes next to DataRate
            setting.SetPropertyNextToAnotherProperty(nameof(MaxBytesPerSecond), nameof(DataRate));

            // === Layout group ===
            setting.SetPropertyGeneralInformation(nameof(WindowSize), "Window Size", "Initial window dimensions", "Layout");
            setting.SetPropertyGeneralInformation(nameof(WindowPosition), "Window Position", "Initial window location", "Layout");

            setting.SetSizePropertyDigits(nameof(WindowSize), 0);
            setting.SetSizePropertyFieldDisplayText(nameof(WindowSize), "W", "H");
            setting.SetSizePropertyWidthValueRange(nameof(WindowSize), 320, 3840);
            setting.SetSizePropertyHeightValueRange(nameof(WindowSize), 240, 2160);

            setting.SetPointPropertyDigits(nameof(WindowPosition), 0);

            // Line up position and size
            setting.SetPropertyNextToAnotherProperty(nameof(WindowPosition), nameof(WindowSize));

            // === DateTime group ===
            setting.SetPropertyGeneralInformation(nameof(LastConnected), "Last Connected", "Timestamp of the last successful connection", "DateTime");
            setting.SetPropertyGeneralInformation(nameof(CertificateExpiry), "Cert Expiry", "Date and time when the certificate expires", "DateTime");
            setting.SetPropertyEditorStyle(nameof(CertificateExpiry), AxControls.Controls.ValueEditorStyle.DateTime_DateAndTime);

            setting.SetPropertyGeneralInformation(nameof(Balance), "重量", "", "Currency");
            setting.SetNumericTypePropertyPrefix(nameof(Balance), "$");

            return setting;
        }
    }
}
